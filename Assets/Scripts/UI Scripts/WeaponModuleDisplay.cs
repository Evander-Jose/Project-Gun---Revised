using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponModuleDisplay : MonoBehaviour
{
    public GameObject moduleTextPrefab;
    public IntVariable maxModules;
    public TextMeshProUGUI[] moduleLabels;
    private List<WeaponModule> weaponModules = new List<WeaponModule>();

    private void Start()
    {
        List<TextMeshProUGUI> generatedLabels = new List<TextMeshProUGUI>();
        for(int i = 0; i < maxModules.DefaultValue; i++)
        {
            GameObject newLabel = Instantiate(moduleTextPrefab, transform, false);
            generatedLabels.Add(newLabel.GetComponent<TextMeshProUGUI>());
        }
        moduleLabels = generatedLabels.ToArray();
    }

    private void Update()
    {
        StartCoroutine(DisplayModules(PlayerWeaponControls.instance.playerWeaponUser.activeWeapon.weaponModules));
    }

    private IEnumerator DisplayModules(List<WeaponModule> listOfModules)
    {
        for (int i = 0; i < listOfModules.Count; i++)
        {
            if (moduleLabels[i] != null)
                moduleLabels[i].text = listOfModules[i].name;
            else
                moduleLabels[i].text = "No Module";
            yield return new WaitForSeconds(0.05f);
        }
    }
}
