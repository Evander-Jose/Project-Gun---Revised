using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Fun fact, you could technically leave a
//weapon component with a weapon component type of null, 
//and that particular instance would be ignored by the scheduler.
public class GiveWeaponAmmoOnKill : WeaponComponent
{
    public RaycastShooter raycastShooter;
    public GameObject ammoPickupPrefab;
    [Range(0f, 1f)] public float dropChances;

    public override void ComponentOnCancel()
    {
        //Because I plan to mark this weapon ammo on kill component with a Base
        //weapon component type, there will be nothing on here.

        //Oh, and keep in mind to keep the raycast shooter's weapon type to null.
    }

    //Component On Invoked will be called by the left click button, only when it
    //is marked with the 'Base' weapon component type.
    public override void ComponentOnInvoked()
    {
        //Fire raycast:
        GameObject target = raycastShooter.GetTargetByRaycast();

        bool doSpawn = false;

        //Damage the target
        if(target != null)
        {
            Health healthComponent = target.GetComponent<Health>();
            if (healthComponent)
            {
                //Determine whether the enemy hit would die from the attack:
                if ((healthComponent.currentHealth - raycastShooter.damageAmount) <= 0f)
                {
                    //If yes, then set this local bool to true,
                    doSpawn = true;
                } else
                {
                    //if not then false.
                    doSpawn = false;
                }

                healthComponent.DealDamage(raycastShooter.damageAmount);
            }
        }

        bool successfulRoll = Random.value <= dropChances;

        if(doSpawn && successfulRoll)
        {
            //Spawn ammo drop at the position of the thing that was hit:
            Instantiate(ammoPickupPrefab, target.transform.position, Quaternion.identity);
        }
    }
}
