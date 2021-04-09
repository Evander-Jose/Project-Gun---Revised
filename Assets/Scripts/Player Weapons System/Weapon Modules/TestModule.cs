using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Test Weapon Module")]
public class TestModule : WeaponModule
{
    public GameObject testPrefab;

    public override GameObject GetTarget()
    {
        Debug.Log("Targeting module invoked");
        return testPrefab;
    }

    public override void InflictDamage(Health other)
    { 
        Debug.Log("Damage module invoked on " + other.gameObject.name);
    }

    public override void ModifyGunProperties(GunSettings gunSettings)
    {
        gunSettings.damage += 3.5f;
        gunSettings.fireRate += 3f;
    }
}
