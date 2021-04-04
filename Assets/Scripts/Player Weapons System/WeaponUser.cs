using System.Collections;
using UnityEngine;


public class WeaponUser : MonoBehaviour
{
    public Weapon activeWeapon;

    public void UseWeapon()
    {
        GameObject acquiredTarget = activeWeapon.GetTarget();

        if (acquiredTarget == null) return;

        //Debug.Log(gameObject.name + " has used weapon at " + acquiredTarget.name + " with the weapon, " + activeWeapon.name);

        Health healthComponent = acquiredTarget.GetComponent<Health>();
        if(healthComponent != null)
        {
            //Debug.Log(activeWeapon.gameObject.name + " has dealt some amount of damage to " + healthComponent.gameObject);
            activeWeapon.InflictDamageToTarget(healthComponent);
        }
    }
}
