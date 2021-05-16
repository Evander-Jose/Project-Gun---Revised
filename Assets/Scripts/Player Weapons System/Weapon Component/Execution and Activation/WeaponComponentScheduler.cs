using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponentScheduler : MonoBehaviour
{
    //The main purpose of this script is to execute the functions of active
    //weapon components, in order of priority.

    //To execute the other weapon components other than the base component, the player must
    //first right click, then left click. 

    //The job of the scheduler is to determine which components are base functions of a weapon,
    //and which ones are extra components, which can only be executed when that component is active, and while right click is being pressed down.

    //The needed arrays:
    private WeaponComponent[] allWeaponComponents;
    private WeaponComponent[] baseWeaponComponents;
    private WeaponComponent[] auxilliaryWeaponComponents;

    //The amount of time waited, between executing the update function of 
    //one component and executing the next.
    [SerializeField] private float executionDelay = 0.05f;
    public WeaponComponentType baseType;

    void Start()
    {
        //Get all WeaponComponent MonoBehaviors from children:
        allWeaponComponents = GetComponentsInChildren<WeaponComponent>();

        //Declare base component list:
        List<WeaponComponent> temp_baseComponents = new List<WeaponComponent>();

        //Search for the base components:
        foreach(WeaponComponent weaponComponent in allWeaponComponents)
        {
            if(weaponComponent.weaponComponentType.name == baseType.name)
            {
                temp_baseComponents.Add(weaponComponent);
            }
        }
        temp_baseComponents.Sort(); //Sort by priority
        baseWeaponComponents = temp_baseComponents.ToArray();

        //Declare list of auxilliary components:
        List<WeaponComponent> temp_additionalComponents = new List<WeaponComponent>();

        //Search for auxilliary components:
        foreach(WeaponComponent weaponComponent in allWeaponComponents)
        {
            if (weaponComponent.weaponComponentType.name == baseType.name || weaponComponent.weaponComponentType == null) continue;

            temp_additionalComponents.Add(weaponComponent);
        }
        temp_additionalComponents.Sort(); //Sort by priority
        auxilliaryWeaponComponents = temp_additionalComponents.ToArray();

        //Make all (auxilliary) children inactive:
        foreach(WeaponComponent wc in auxilliaryWeaponComponents)
        {
            wc.gameObject.SetActive(false);
        }
    }

    bool rightClickMode = false;

    void Update()
    {

        //The actual state machine itself:

        //When right click is being held down,
        if(rightClickMode)
        {
            //Check for left click input, and then execute all active auxilliary modules:
            if(Input.GetButtonDown("Fire1"))
            {
                //Debug.Log("MODULE FIRED");

                //Execute in order of priority (auxilliary only):
                foreach(WeaponComponent wc in auxilliaryWeaponComponents)
                {
                    if (wc.gameObject.activeInHierarchy == false) continue;
                    wc.ComponentOnInvoked();
                }
            } 

            //while right click was being held, and then released:
            if(Input.GetButtonUp("Fire2"))
            {
                Debug.Log("Cancelling MODULE MODE");
                //Cancel the effects of the auxilliary modules:
                foreach(WeaponComponent wc in auxilliaryWeaponComponents)
                {
                    if (wc.gameObject.activeInHierarchy == false) continue;
                    wc.ComponentOnCancel();
                }
            }

        } else
        {
            //Fires like normal, without the rigght click button being held down:
            if(Input.GetButtonDown("Fire1"))
            {
                //Execute in order of priority (base only)
                foreach(WeaponComponent wc in baseWeaponComponents)
                {
                    if (wc.gameObject.activeInHierarchy == false) continue;
                    wc.ComponentOnInvoked();
                }
            }
        }

        if (Input.GetButton("Fire2")) //If right click is held down,
        {
            //turn the bool to true:
            //Debug.Log("MODULE MODE!");
            rightClickMode = true;
        }
        else
        {
            rightClickMode = false;
        }
    }
}
