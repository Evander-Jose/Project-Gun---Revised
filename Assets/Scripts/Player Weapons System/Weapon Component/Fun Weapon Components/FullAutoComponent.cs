using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAutoComponent : WeaponComponent
{
    bool fullAutoMode = false;
    float timeSinceLastAttack = 0f;
    public float attackDelay = 0.2f;
    public RaycastShooter baseRaycastShooter;

    //Cancel just means when the player let fo of the right click:
    public override void ComponentOnCancel()
    {
        //Debug.Log("FULL AUTO DISABLED");
        fullAutoMode = false;
    }

    //OnInvoked, means when the player held right click, and pressed left click.
    public override void ComponentOnInvoked()
    {
        //Debug.Log("FULL AUTO ENABLED");
        fullAutoMode = true;
    }

    //Update, means normal Update method
    private void Update()
    {
        //Debug.Log("FULL AUTO: " + fullAutoMode);
        if(fullAutoMode == false)
        {
            timeSinceLastAttack += Time.deltaTime;
            return;
        } 
        else
        {
            if(Input.GetButton("Fire1") && timeSinceLastAttack > attackDelay)
            {
                timeSinceLastAttack = 0f;

                //Yeah, I know this is kinda of a hacky solution to my own solution, 
                //but I guess this works... Is this what people call emergent design?
                baseRaycastShooter.FireRaycast();
            }
            timeSinceLastAttack += Time.deltaTime;
        }
    }
}
