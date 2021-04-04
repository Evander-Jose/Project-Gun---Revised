using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolCollection : MonoBehaviour
{
    //This design of object pooling is rather easy to use, but:
    //ony use this, to activate and deactivate objects from a group, where
    //which object that is being activated doesn't matter,
    //the size of pooled objects is unlikely to change.
    private Queue<GameObject> deactivatedObjects = new Queue<GameObject>();
    private Queue<GameObject> activatedObjects = new Queue<GameObject>();

    public ObjectPoolType poolType;
    public void RegisterPooledObject(GameObject objectToAdd)
    {
        deactivatedObjects.Enqueue(objectToAdd);
        objectToAdd.SetActive(false);
    }

    public GameObject ActivateObject()
    {
        GameObject activatedObject = deactivatedObjects.Dequeue();

        activatedObject.SetActive(true);

        activatedObjects.Enqueue(activatedObject);
        return activatedObject;
    }
    public GameObject DeactivateObject()
    {
        GameObject deactivatedObject = activatedObjects.Dequeue();

        deactivatedObject.SetActive(false);

        deactivatedObjects.Enqueue(deactivatedObject);

        return deactivatedObject;
    }
}
