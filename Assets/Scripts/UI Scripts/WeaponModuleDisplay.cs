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
        //In case the weapon has no modules:
        if(listOfModules.Count <= 0)
        {
            foreach(TextMeshProUGUI text in moduleLabels)
            {
                text.text = "No Module";
            }
        }

        int emptyIndexes = maxModules.DefaultValue - listOfModules.Count;
        int firstEmptyIndex = emptyIndexes - (emptyIndexes - 1);
        firstEmptyIndex--;

        //However, it doesn't cover all of the labels. So if a weapon had one module, the rest of the three
        //labels are not updated.

        //This does just that:
        //Update empty labels:

        for (int f = firstEmptyIndex; f < moduleLabels.Length; f++)
        {
            moduleLabels[f].text = "No Module";
            
        }

        //Fill in the labels, where there are modules
        for (int i = 0; i < listOfModules.Count; i++)
        {
            if (moduleLabels[i] != null)
                moduleLabels[i].text = listOfModules[i].name;

            yield return null;
        }

        
    }
}
