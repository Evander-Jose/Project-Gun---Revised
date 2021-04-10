using System.Collections;
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

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            List<WeaponModule> weaponModules = new List<WeaponModule>();
            weaponModules = playerWeaponUser.activeWeapon.weaponModules;
            foreach(WeaponModule module in weaponModules)
            {
                playerWeaponUser.activeWeapon.RemoveWeaponModule(module);
            }
        }
    }
}
