using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Gun : Weapon
{
    public GunSettings gunSetting;
    public IntVariable ammo;
    [Space]
    public Transform firstPersonCamera;
    public LayerMask targetLayerMask;
    [Space]
    [Header("Tracer Particle Effect Settings")]  
    public ObjectPoolType tracerPoolType;
    public GameObject tracerParticle;
    public int tracerParticlePoolSize = 0;
    [Space]
    public float tracerTravelSpeed = 30f;
    public float tracerLifetime = 0.7f;
    [Space]
    public Transform muzzle;
    public Animator anim;


    private float timeSinceLastFire = 0f;
    private bool canFire = true;
    private ObjectPoolCollection objectPool;

    public override event DelegateGetTarget OnGetTargets;
    public override event DelegateDamageInflict OnTargetDamage;

    private void Awake()
    {
        //Find the correct object pool object:
        ObjectPoolCollection[] objectPoolsInScene = FindObjectsOfType<ObjectPoolCollection>();
        foreach(ObjectPoolCollection objPool in objectPoolsInScene)
        {
            if(objPool.poolType.name == tracerPoolType.name)
            {
                objectPool = objPool;
                break;
            } else
            {
                continue;
            }
        }


        //Registers some tracer particles to the object pool asset.
        for(int i = 0; i < tracerParticlePoolSize; i++)
        {
            GameObject newTracer = Instantiate(tracerParticle, objectPool.transform, false);
            newTracer.transform.position = Vector3.zero;
            objectPool.RegisterPooledObject(newTracer);
        }
    }

    public override GameObject GetTarget()
    {
        if (canFire == false) return null;
        
        if(gunSetting.ammoConsumption <= ammo.Value)
        {
            ammo.Value -= gunSetting.ammoConsumption;
        } else
        {
            return null;
        }

        //Reset the firing delay timer:
        timeSinceLastFire = 0f;

        //Invokes any functions that are subscribed to the on get targets event (used by weapon modules)
        if(OnGetTargets != null)
        {
            List<GameObject> targetsByModules = new List<GameObject>();
            targetsByModules.Add(OnGetTargets.Invoke());
            foreach(GameObject target in targetsByModules)
            {
                if (target == null) continue;
                Debug.Log(target);
            }
        }

        RaycastHit rayHit;
        Ray gunRay = new Ray(transform.position, firstPersonCamera.transform.forward);

        //Debug.DrawRay(transform.position, firstPersonCamera.transform.forward * 10f, Color.red, 5f);
        //Activate a tracer gameobject and then give it velocity:
        GameObject activatedTracer = objectPool.ActivateObject();
        activatedTracer.transform.position = muzzle.position;

        //Debug.Log("Tracer fired from " + activatedTracer.transform.localPosition);

        //Where the visual effects happen:

        //Tracer effects:
        activatedTracer.GetComponent<Rigidbody>().velocity = firstPersonCamera.forward * tracerTravelSpeed;
        Invoke("TurnOffTracer", tracerLifetime);

        //Animation effect:
        anim.SetTrigger("shoot");

        //The raycasting
        if (Physics.Raycast(gunRay, out rayHit, gunSetting.range, targetLayerMask))
        {
            return rayHit.collider.gameObject;
        } else
        {
            return null;
        }
    }

    private void TurnOffTracer()
    {
        objectPool.DeactivateObject();
    }

    public override void InflictDamageToTarget(Health other)
    {
        if (OnTargetDamage != null)
        {
            Debug.Log("On Target Damage was invoked, a damage modifying module has been invokedds");
            OnTargetDamage.Invoke(other);
        }

        other.DealDamage(gunSetting.damage);
    }

    private void Update()
    {
        timeSinceLastFire += Time.deltaTime;
        if (timeSinceLastFire > (1f / gunSetting.fireRate))
        {
            canFire = true;
        }
        else
        {
            canFire = false;
        }
    }

    public override void ApplyWeaponModule(WeaponModule moduleToApply)
    {
        //The obligatory null check:
        if (moduleToApply == null) return;

        //For now, I have no plans of making modules stack, so here's a check to prevent that:
        if (weaponModules.Contains(moduleToApply) == true) return;

        weaponModules.Add(moduleToApply);
        
        OnGetTargets += moduleToApply.GetTarget;
        OnTargetDamage += moduleToApply.InflictDamage;

        moduleToApply.ModifyGunProperties(gunSetting);
    }

    public override void RemoveWeaponModuleEffects(WeaponModule module)
    {
        //Remove module, and unsub from the events:
        if (module == null) return;
        if (weaponModules.Contains(module) == false) return;
        if (weaponModules.Count >= maximumModules.DefaultValue) return;

        OnGetTargets -= module.GetTarget;
        OnTargetDamage -= module.InflictDamage;

        module.RevertGunProperties(gunSetting);
    }


}
