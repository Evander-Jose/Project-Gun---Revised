using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public List<GameObject> childrenGameObject = new List<GameObject>();

    private int chosenIndex = 0;

    private void Start()
    {
        //Updates the childrenGameObject list:
        List<GameObject> currentGameObjects = new List<GameObject>();
        foreach (Transform t in transform)
        {
            currentGameObjects.Add(t.gameObject);
        }
        childrenGameObject = currentGameObjects;

        StartCoroutine(ChooseWeapon(chosenIndex));
    }

    private void Update()
    {
        //Updates the childrenGameObject list:
        List<GameObject> currentGameObjects = new List<GameObject>();
        foreach(Transform t in transform)
        {
            currentGameObjects.Add(t.gameObject);
        }
        childrenGameObject = currentGameObjects;

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(ChooseWeapon(0));
        } 
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(ChooseWeapon(1));
        }

        if(Input.mouseScrollDelta.y > 0)
        {
            chosenIndex++;
            if(chosenIndex > childrenGameObject.Count - 1)
            {
                chosenIndex = 0;
            }

            StartCoroutine(ChooseWeapon(chosenIndex));
        }
        else if(Input.mouseScrollDelta.y < 0)
        {
            chosenIndex--;
            if(chosenIndex < 0)
            {
                chosenIndex = childrenGameObject.Count - 1;
            }

            StartCoroutine(ChooseWeapon(chosenIndex));
        }
    }

    private IEnumerator ChooseWeapon(int index)
    {
        for(int i = 0; i <= childrenGameObject.Count - 1; i++)
        {
            if(i == index)
            {
                childrenGameObject[i].SetActive(true);
            } else
            {
                childrenGameObject[i].SetActive(false);
            }

            yield return null;
        }
    }
}
