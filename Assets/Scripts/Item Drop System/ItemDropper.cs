using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public DropItem[] dropItems;

    public void RollForDropItem()
    {
        foreach(DropItem item in dropItems)
        {
            GameObject rolledItem = item.RollDropObject();
            if (rolledItem != null)
            {
                GameObject droppedItem = Instantiate(rolledItem, transform.position, Quaternion.identity);
                break;
            } 
        }
    }
}
