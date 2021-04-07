using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Test Weapon Module")]
public class TestModule : WeaponModule
{
    public override GameObject GetTarget()
    {
        Debug.Log("Targeting module invoked");
        return null;
    }

    public override void InflictDamage(Health other)
    { 
        Debug.Log("Damage module invoked on " + other.gameObject.name);
    }
}
