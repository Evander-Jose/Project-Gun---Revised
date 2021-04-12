using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponModuleDisplay : MonoBehaviour
{
    public GameObject moduleTextPrefab;

    private void Update()
    {
        

        StartCoroutine(DisplayModules(PlayerWeaponControls.instance.playerWeaponUser.activeWeapon.weaponModules));
        
    }

    private IEnumerator DisplayModules(List<WeaponModule> listOfModules)
    {

        for (int i = 0; i < listOfModules.Count; i++)
        {
            //Create a new module text prefab:
            GameObject newText = Instantiate(moduleTextPrefab, transform, false);
            TextMeshProUGUI text = newText.GetComponent<TextMeshProUGUI>();
            text.text = listOfModules[i].name;
            Destroy(newText, Time.fixedDeltaTime);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }
}
