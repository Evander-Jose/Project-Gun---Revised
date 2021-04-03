﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponControls : MonoBehaviour
{
    public WeaponUser playerWeaponUser;
    public WeaponSwitching playerWeaponSwitching;

    private void Update()
    {
        int activeWeaponIndex = playerWeaponSwitching.selectedWeapon;
        playerWeaponUser.activeWeapon = playerWeaponSwitching.weapons[activeWeaponIndex];

        if(Input.GetButton("Fire1"))
        {
            playerWeaponUser.UseWeapon();
        }
    }
}