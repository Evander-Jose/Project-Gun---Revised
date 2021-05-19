using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Vector2 roomPosition;
    [SerializeField] private GameObject northDoor;
    [SerializeField] private GameObject southDoor;
    [SerializeField] private GameObject westDoor;
    [SerializeField] private GameObject eastDoor;
    public LayerMask groundLayerMask;

    private bool inBattle = false; //The whole purpose of marking the room as being in battle is so that there can be no repeat triggering of beginning battle.
    private bool cleared = false; //This is to mark the room as cleared, as to prevent, you guessed it, repeating the battle.

    private void OnEnable()
    {
        //Just to be extra extra safe.
        inBattle = false;
        cleared = false;
    }

    public void OpenDoorsToAdjacentRooms()
    {
        StartCoroutine(OpenDoorsToAdjacentRooms(northDoor));
        StartCoroutine(OpenDoorsToAdjacentRooms(southDoor));
        StartCoroutine(OpenDoorsToAdjacentRooms(westDoor));
        StartCoroutine(OpenDoorsToAdjacentRooms(eastDoor));
    }

    public void CloseAllDoors()
    {
        northDoor.SetActive(true);
        southDoor.SetActive(true);
        westDoor.SetActive(true);
        eastDoor.SetActive(true);
    }

    public IEnumerator OpenDoorsToAdjacentRooms(GameObject doorToCheckFrom)
    {
        Collider[] colliders = Physics.OverlapSphere(doorToCheckFrom.transform.position, 3f, groundLayerMask);
        //If inside the array of scanned things, you find a collider that doesn't share the same transform as this orginal object, open that door.
        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].transform != transform)
            {
                Debug.Log("Opening door");
                doorToCheckFrom.SetActive(false);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }    

    public void GoIntoBattleMode()
    {
        if(inBattle == true || cleared == true)
        {
            return;
        }

        inBattle = true;
        CloseAllDoors();
    }

    public void MarkRoomAsCleared()
    {
        cleared = true;
        OpenDoorsToAdjacentRooms();
    }
}
