using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class WeaponComponent : MonoBehaviour, IComparable<WeaponComponent>
{
    public abstract void ComponentOnInvoked();
    public abstract void ComponentOnCancel();

    public int priority;
    public WeaponComponentType weaponComponentType;

    public int CompareTo(WeaponComponent other)
    {
        if(other.priority > this.priority)
        {
            return -1;
        } else if(other.priority < this.priority)
        {
            return 1;
        } else
        {
            return 0;
        }
    }
}


