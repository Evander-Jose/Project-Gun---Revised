using System.Collections;
using UnityEngine;


public class Gun : Weapon
{
    public GunSettings gunSetting;
    [Space]
    public Transform firstPersonCamera;
    public LayerMask targetLayerMask;
    [Space]
    [Header("Tracer Particle Effect Settings")]
    public ObjectPoolCollection objectPool;
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

    private void Awake()
    {
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

        timeSinceLastFire = 0f;

        RaycastHit rayHit;
        Ray gunRay = new Ray(transform.position, firstPersonCamera.transform.forward);

        //Debug.DrawRay(transform.position, firstPersonCamera.transform.forward * 10f, Color.red, 5f);
        //Activate a tracer gameobject and then give it velocity:
        GameObject activatedTracer = objectPool.ActivateObject();
        activatedTracer.transform.position = muzzle.position;
        Debug.Log("Tracer fired from " + activatedTracer.transform.localPosition);
        activatedTracer.GetComponent<Rigidbody>().velocity = firstPersonCamera.forward * tracerTravelSpeed;

        Invoke("TurnOffTracer", tracerLifetime);

        anim.SetTrigger("shoot");

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
}
