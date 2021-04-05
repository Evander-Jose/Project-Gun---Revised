using System.Collections;
using UnityEngine;


[CreateAssetMenu(menuName = "Drop Item")]
public class DropItem : ScriptableObject
{
    public GameObject dropObjectPrefab;
    [Range(0f, 1f)]public float dropChance;

    public GameObject RollDropObject()
    {
        float randomRoll = Random.value;
        if((1 - dropChance) <= randomRoll)
        {
            return dropObjectPrefab;
        } else
        {
            return null;
        }
    }
}
