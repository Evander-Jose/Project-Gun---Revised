using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponComponentStand : MonoBehaviour
{
    public WeaponComponentRewardSet rewardSet;
    public WeaponComponentType weaponComponentToGive;
    public Collider interactionTrigger;
    public ModuleGiver moduleGiver;

    private bool canInteract;
    public TextMeshPro[] textMeshes;

    private void Start()
    {

    }

    public void DropWeaponComponent()
    {
        Debug.Log("weapon component dropped");
        WeaponComponentType componentType = rewardSet.RollForDrop();

        //The only reason why the function above would return null is if the function decided that there would be no weapon components to give at all.
        if (componentType == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            //If the function has decided to give the player something, then activate, and assign:
            weaponComponentToGive = componentType;
            gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (!canInteract)
        {
            SetActiveText(false);
            return;
        } 
        
        //When the player hits the interaction trigger of the module stand, then the text saying which module it unlocks will appear:
        //The trigger can only be triggered if the DropWeaponComponent method activates this gameObject.
        SetActiveText(canInteract);
        SetTextMeshesText("Unlocks " + weaponComponentToGive.name);
        


        if(Input.GetKeyDown(KeyCode.E))
        {
            //When the player presses down the interact button, then apply the module to the player:
            moduleGiver.ActivateModuleInActiveWeapon(weaponComponentToGive);
        }
    }

    private void SetActiveText(bool value)
    {
        foreach(TextMeshPro tmp in textMeshes)
        {
            tmp.gameObject.SetActive(value);
        }
    }

    private void SetTextMeshesText(string value)
    {
        foreach(TextMeshPro tmp in textMeshes)
        {
            tmp.text = value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canInteract = false;
    }
}
