using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModuleApplier : MonoBehaviour
{
    public WeaponModule weaponModuleToApply;
    private WeaponSwitching currentWeaponObject;

    private void Start()
    {
        currentWeaponObject = FindObjectOfType<WeaponSwitching>();
    }

    public void ApplyWeaponModule()
    {
        int i = currentWeaponObject.selectedWeapon;
        currentWeaponObject.weapons[i].ApplyWeaponModule(weaponModuleToApply);
    }
}
