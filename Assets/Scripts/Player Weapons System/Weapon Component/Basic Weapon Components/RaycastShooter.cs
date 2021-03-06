using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//These are a new line of 'weapon components', which are monobehaviors which would be 
//attached to the weapon gameobjects themselves in an attempt to make weapons more 
//modular in their function.
public class RaycastShooter : WeaponComponent
{
    public float distance;
    public float damageAmount = 2f;
    [Range(0f, 3f)] public float attackDelay = 0.5f;
    private float timeSinceLastShot = 0f;
    [Space]
    [Header("Raycast Settings")]
    public Transform muzzleTransform;
    public Transform firstPersonCameraTransform;
    public LayerMask targetLayerMask;
    [Header("Tracer Particles Settings")]
    private ObjectPoolCollection tracerObjectPool;
    [SerializeField] private float tracerLife = 0.5f;
    public ObjectPoolType tracerObjectPoolType;
    public float tracerTravelSpeed;

    private void Awake()
    {
        ObjectPoolCollection[] objectPoolsInScene = FindObjectsOfType<ObjectPoolCollection>();
        foreach(ObjectPoolCollection objPool in objectPoolsInScene)
        {
            if(objPool.poolType == tracerObjectPoolType)
            {
                tracerObjectPool = objPool;
                break;
            }
        }
    }

    public GameObject GetTargetByRaycast()
    {
        //Tracer particle spawn:
        SpawnTracer();

        //Raycast:
        RaycastHit rayHit = new RaycastHit();
        Ray shootRay = new Ray(firstPersonCameraTransform.position, firstPersonCameraTransform.forward);
            
        //Raycast Check:
        if(Physics.Raycast(shootRay, out rayHit, distance, targetLayerMask, QueryTriggerInteraction.Ignore))
        {
            //Debug.Log(rayHit.collider.gameObject.name + " has been hit!");
            /*Health healthComponent = rayHit.collider.GetComponent<Health>();
            if(healthComponent != null)
            {
                healthComponent.DealDamage(damageAmount);
            }*/
            return rayHit.collider.gameObject;
        } else
        {
            return null;
        }
    }

    private void SpawnTracer()
    {
        GameObject newTracer = tracerObjectPool.ActivateObject();

        //Put the tracer onto the muzzle:
        newTracer.transform.position = muzzleTransform.position;

        Rigidbody tracerRigidbody = newTracer.GetComponent<Rigidbody>();
        tracerRigidbody.velocity = muzzleTransform.forward * tracerTravelSpeed;

        Invoke("DeactivateTracer", tracerLife);
    }

    private void DeactivateTracer()
    {
        tracerObjectPool.DeactivateObject();
    }

    public override void ComponentOnInvoked()
    {
        bool canAttack = timeSinceLastShot > attackDelay;
        GameObject target = null;
        if (canAttack)
        {
            target = GetTargetByRaycast();
            timeSinceLastShot = 0f;
        }

        if (target != null)
        {
            DamageTarget(target);
        }
        
    }

    public void DamageTarget(GameObject target)
    {
        Health healthComponent = target.GetComponent<Health>();
        if (healthComponent != null)
        {
            healthComponent.DealDamage(damageAmount);
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }


    public override void ComponentOnCancel()
    {
        //Do nothing, because this is a base weapon component with no additional functionality!
    }
}
