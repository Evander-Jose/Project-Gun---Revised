using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleGiver : MonoBehaviour
{
    public void ActivateModuleInActiveWeapon(WeaponComponentType weaponComponentType)
    {
        Debug.Log("Activated Module: " + weaponComponentType.name);
        WeaponComponentActivator.activeInstance.ActivateWeaponComponent(weaponComponentType);
    }
}
