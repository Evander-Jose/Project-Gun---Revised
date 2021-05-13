using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Type")]
public class WeaponType : ScriptableObject
{
    public WeaponComponentType[] compatibleWeaponComponentTypes;
    public bool CheckCompatibility(WeaponComponentType type)
    {
        foreach(WeaponComponentType wct in compatibleWeaponComponentTypes)
        {
            if (wct.name == type.name)
            {
                return true;
            }
        }

        return false;
    }
}
