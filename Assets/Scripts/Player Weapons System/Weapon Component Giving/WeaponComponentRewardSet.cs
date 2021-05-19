using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Component Reward Set")]
public class WeaponComponentRewardSet : ScriptableObject
{
    [Range(0f, 1f)] public float rewardChance; //The chances of whether or not a weapon component would drop at all:
    public WeaponComponentDrop[] possibleDrops;

    [System.Serializable]
    public class WeaponComponentDrop
    {
        public WeaponComponentType weaponComponentType;
        [Range(0f, 1f)] public float probability;
    }

    public WeaponComponentType RollForDrop()
    {
        float roll = Random.value;
        bool dropAtAll = rewardChance >= roll;

        if(dropAtAll)
        {
            float totalRatio = 0f;
            foreach(WeaponComponentDrop wcd in possibleDrops)
            {
                totalRatio += wcd.probability;
            }

            totalRatio *= Random.value;

            //The weighted probability thingy goes in here:
            foreach(WeaponComponentDrop wcd in possibleDrops)
            {
                totalRatio -= wcd.probability;

                //If the total ratio does not fall below zero after being reduced, then skip the current element:
                if(totalRatio <= 0f == false)
                {
                    continue;
                } else
                {
                    return wcd.weaponComponentType;
                }
            }

            //This shouldn't be executed at all:
            Debug.LogWarning("The weapon component reward set has returned nothing! I don't know why this message appeared!");
            return null;

        } else
        {
            return null;
        }
    }
}
