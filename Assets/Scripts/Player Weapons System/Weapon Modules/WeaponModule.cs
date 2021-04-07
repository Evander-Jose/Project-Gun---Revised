using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Module")]
public abstract class WeaponModule : ScriptableObject
{
    public abstract void InflictDamage(Health other);
    public abstract GameObject GetTarget();
}
