using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponComponentActivator : MonoBehaviour
{
    public WeaponType weaponType;

    public WeaponComponent[] allAvailableWeaponComponents;
    public WeaponComponentType baseType;

    public static WeaponComponentActivator activeInstance;

    private void Update()
    {
        if(activeInstance == null || activeInstance != this)
            activeInstance = this;

        //Debug.Log("Current Active Weapon: " + gameObject.name);
    }

    private void Awake()
    {
        allAvailableWeaponComponents = GetComponentsInChildren<WeaponComponent>();
    }

    public void ActivateWeaponComponent(WeaponComponentType weaponComponentToActivate)
    {
        if (weaponType.CheckCompatibility(weaponComponentToActivate) == false) return;

        Debug.Log(weaponComponentToActivate.name + " will be activated!");

        foreach(WeaponComponent wc in allAvailableWeaponComponents)
        {
            if(wc.weaponComponentType.name == baseType.name)
            {
                continue;
            }
             
            if(weaponComponentToActivate.name == wc.weaponComponentType.name)
            {
                Debug.Log(weaponComponentToActivate.name + " was activated in " + gameObject.name);
                wc.gameObject.SetActive(true);
            }
        }
    }
}


