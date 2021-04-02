using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gun Settings")]
public class GunSettings : ScriptableObject
{
    public float range;
    public float damage;
    public float fireRate;
}
