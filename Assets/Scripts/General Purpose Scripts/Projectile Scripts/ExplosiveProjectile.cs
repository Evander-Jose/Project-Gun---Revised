using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileBehavior))]
public class ExplosiveProjectile : MonoBehaviour
{
    private ProjectileBehavior thisProjectile;
    public float explosionRadius;
    public float groundZeroRadius;
    [Space]
    public float explosionDamage;
    [Range(0f, 3.5f)] public float explosionDelay;
    [Space]
    public LayerMask targetLayerMask; 

    private void Start()
    {
        thisProjectile = GetComponent<ProjectileBehavior>();
        thisProjectile.onProjectileCollision += Explode; 
    }

    private void Explode(GameObject other) //Don't mind the 'other' GameObject parameter in this case. Really.
    {
        //start the countdown:
        StartCoroutine(ExplosionCoroutine());
    }

    private IEnumerator ExplosionCoroutine()
    {
        float timeElapsed = 0f;

        while (timeElapsed < explosionDelay)
        {
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        

        //Kaboom!
        
        //Frick it, just use the OverlapSphere function because SphereCast isn't doing what I want it to do.
        Collider[] sphereCheckColliders = Physics.OverlapSphere(transform.position, explosionRadius, targetLayerMask, QueryTriggerInteraction.Ignore);
        
        if(sphereCheckColliders.Length > 1)
        {
            for(int i = 0; i < sphereCheckColliders.Length - 1; i++)
            {
                //Cache the current gameobject in the for loop:
                GameObject currentGameObject = sphereCheckColliders[i].gameObject;

                Debug.Log("Got hit by an explosion! : " + currentGameObject.name);

                //Get the health component from the colliders from the sphere check:
                Health otherHealthComponent = currentGameObject.GetComponent<Health>();
                if (otherHealthComponent != null)
                {
                    //If there is a health component, deal damage based on the distance from the point of explosion.
                    float totalDamageDealt = CalculateExplosionDamage(currentGameObject.transform.position);
                    otherHealthComponent.DealDamage(totalDamageDealt);
                }

                //Because I'm calling GetComponent, which is a resource-heavy function, I better mitigate that by 
                //calling that function after 1/10th of a second, which is a long time in computing terms.
                yield return new WaitForSeconds(0.1f);
            }           
        }



        //And lastly, get rid of the evide-, I mean the projectile itself after it explodes:
        Destroy(gameObject);
    }

    private float CalculateExplosionDamage(Vector3 targetPosition)
    {
        //first calculate the distance from the projectile to the targetPosition:
        float explosionDistance = Vector3.Distance(targetPosition, transform.position);

        //then calculate the damage multiplier using this handy dandy formula: 1/(distance), given that distance is more than 1.
        float damageMultiplier = 1f;
        if(explosionDistance > groundZeroRadius)
        {
            damageMultiplier = (0.25f*explosionDamage)/explosionDistance;
            float damageOutput = explosionDamage * damageMultiplier;
            return damageOutput;
        } else
        {
            float damageOutput = explosionDamage * damageMultiplier;
            return damageOutput;
        }
    }
}
