using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(WeaponComponentActivator))]
public class WeaponComponentActivatorEditor : Editor
{
    //All that this editor script does is automatically add new types of weapon component types
    //to the weapon type scriptable object:
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        WeaponComponentActivator inspectedObject = (WeaponComponentActivator)target;

        //Gotta clear out the array in the scriptable object first (just to be safe):
        inspectedObject.weaponType.compatibleWeaponComponentTypes = null;

        //Then make an empty, temporary list for weapon component types:
        List<WeaponComponentType> temp = new List<WeaponComponentType>();

        foreach (Transform t in inspectedObject.transform)
        {
            //Pulls the weapon component from each child in the inspected weapon, 
            //and add them to a temporary list of weapon component types:
            WeaponComponent weaponComponent = t.GetComponent<WeaponComponent>();
            if (weaponComponent != null)
            {
                //Use a local for the weaponComponentType to make the code look clean:
                WeaponComponentType weaponComponentType = weaponComponent.weaponComponentType;

                //Makes sure that the component being added is a unique weaponComponent:
                if (temp.Contains(weaponComponentType) == false)
                    temp.Add(weaponComponentType);
            }
            else
                continue;        
        }

        //Use that temporary list of weapon component types to fill the array in the weapon type scriptable object
        inspectedObject.weaponType.compatibleWeaponComponentTypes = temp.ToArray();
    }
}
