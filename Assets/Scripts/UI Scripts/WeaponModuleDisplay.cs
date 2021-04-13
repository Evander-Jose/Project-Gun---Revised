using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponModuleDisplay : MonoBehaviour
{
    public GameObject moduleTextPrefab;
    public TextMeshProUGUI[] moduleLabels;
    private List<WeaponModule> weaponModules = new List<WeaponModule>();

    private void Update()
    {
        StartCoroutine(DisplayModules(PlayerWeaponControls.instance.playerWeaponUser.activeWeapon.weaponModules));
    }

    private IEnumerator DisplayModules(List<WeaponModule> listOfModules)
    {
        for (int i = 0; i < moduleLabels.Length; i++)
        {
            if(moduleLabels[i] != null)
                moduleLabels[i].text = listOfModules[i].name;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
