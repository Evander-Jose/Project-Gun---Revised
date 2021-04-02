using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract GameObject GetTarget();
    public abstract void InflictDamageToTarget(Health other);
}
