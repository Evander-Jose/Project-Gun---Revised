using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public Weapon[] weapons;
    [Space]
    public int selectedWeapon = 0;

    private IEnumerator SelectWeapon(int index)
    {
        if (index <= weapons.Length)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if (i == index)
                {
                    weapons[i].gameObject.SetActive(true);
                }
                else
                {
                    weapons[i].gameObject.SetActive(false);
                }
                yield return new WaitForSeconds(0.02f);
            }
        }
    }

    private void Start()
    {
        StartCoroutine(SelectWeapon(0));
    }

    private void Update()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            selectedWeapon++;
            if(selectedWeapon > weapons.Length - 1)
            {
                selectedWeapon = weapons.Length - 1;
            }
        }

        if(Input.mouseScrollDelta.y < 0)
        {
            selectedWeapon--;
            if(selectedWeapon < 0)
            {
                selectedWeapon = 0;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
        }

        StartCoroutine(SelectWeapon(selectedWeapon));
    }
}
