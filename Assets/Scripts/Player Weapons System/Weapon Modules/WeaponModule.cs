using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponModule : ScriptableObject
{
    public abstract void InflictDamage(Health other);
    public abstract GameObject GetTarget();
    public abstract void ModifyGunProperties(GunSettings gunSettings);
    public abstract void RevertGunProperties(GunSettings gunSettings);
}
