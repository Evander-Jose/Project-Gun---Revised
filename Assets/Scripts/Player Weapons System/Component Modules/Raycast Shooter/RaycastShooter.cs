using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//These are a new line of 'weapon components', which are monobehaviors which would be 
//attached to the weapon gameobjects themselves in an attempt to make weapons more 
//modular in their function.
public class RaycastShooter : MonoBehaviour
{
    public float distance;
    public float damageAmount = 2f;
    [Space]
    [Header("Raycast Settings")]
    public Transform muzzleTransform;
    public Transform firstPersonCameraTransform;
    public LayerMask targetLayerMask;
    [Header("Tracer Particles Settings")]
    private ObjectPoolCollection tracerObjectPool;
    public ObjectPoolType tracerObjectPoolType;
    public float tracerTravelSpeed;

    private void Start()
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

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            //Tracer particle spawn:
            SpawnTracer();

            //Raycast:
            RaycastHit rayHit = new RaycastHit();
            Ray shootRay = new Ray(firstPersonCameraTransform.position, firstPersonCameraTransform.forward);
            
            //Raycast Check:
            if(Physics.Raycast(shootRay, out rayHit, distance, targetLayerMask, QueryTriggerInteraction.Ignore))
            {
                Debug.Log(rayHit.collider.gameObject.name + " has been hit!");
                Health healthComponent = rayHit.collider.GetComponent<Health>();
                if(healthComponent != null)
                {
                    healthComponent.DealDamage(damageAmount);
                }
            }
        }
    }

    private void SpawnTracer()
    {
        GameObject newTracer = tracerObjectPool.ActivateObject();

        //Put the tracer onto the muzzle:
        newTracer.transform.position = muzzleTransform.position;

        Rigidbody tracerRigidbody = newTracer.GetComponent<Rigidbody>();
        tracerRigidbody.velocity = muzzleTransform.forward * tracerTravelSpeed;

        Invoke("DeactivateTracer", 0.1f);
    }

    private void DeactivateTracer()
    {
        tracerObjectPool.DeactivateObject();
    }
}
