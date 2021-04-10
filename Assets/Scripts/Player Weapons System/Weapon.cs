using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract void InflictDamageToTarget(Health other);
    public abstract GameObject GetTarget();

    public delegate GameObject DelegateGetTarget();
    public abstract event DelegateGetTarget OnGetTargets;

    public delegate void DelegateDamageInflict(Health target);
    public abstract event DelegateDamageInflict OnTargetDamage;

    public List<WeaponModule> weaponModules = new List<WeaponModule>();
    public abstract void ApplyWeaponModule(WeaponModule module);
    public abstract void RemoveWeaponModuleEffects(WeaponModule module);
    public void RemoveWeaponModuleFromList(WeaponModule module)
    {
        if (weaponModules.Contains(module) == true)
        weaponModules.Remove(module);
    }
}
