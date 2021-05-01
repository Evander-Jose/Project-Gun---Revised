using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gun Settings")]
public class GunSettings : ScriptableObject
{
    [HideInInspector] public float range;
    [HideInInspector] public float damage;
    [HideInInspector] public float fireRate;
    [HideInInspector] public int ammoConsumption = 1;

    [Header("Default Settings")]
    [SerializeField] private float default_range;
    [SerializeField] private float default_damage;
    [SerializeField] private float default_fireRate;
    [Space]
    [SerializeField] private int default_ammoConsumption = 1;

    private void OnEnable()
    {
        range = default_range;
        damage = default_damage;
        fireRate = default_fireRate;
        ammoConsumption = default_ammoConsumption;
    }
}
