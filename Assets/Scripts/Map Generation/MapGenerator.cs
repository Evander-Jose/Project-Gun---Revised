using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //This map generator randomly generates a map using different rooms.
    //This uses an imaginary sort of coordinate system to represent where rooms are generated.

    public int maxRows = 8;
    public int maxColumns = 8;
    [Space]
    public float roomLength = 50.3f;
    [Space]
    public RoomGenerationSet roomGenerationSet;
    [Space]
    public GameObject startRoomPrefab;
    public GameObject endRoomPrefab;
    [Space]
    public List<GameObject> generatedRooms;


    private void Start()
    {
        StartCoroutine(GenerateRooms());

    }

    //This is the main coroutine function that does most of the generating work:
    public IEnumerator GenerateRooms()
    {
        GenerateStartAndEnd();
        for(int i = 0; i < maxRows + 1; i++)
        {
            if (i != (maxRows))
            {
                StartCoroutine(GenerateColumnUpwards(new Vector2(i, 1), Random.Range(1, maxColumns - 1)));
            }
            else
            {
                //Generate the last column:
                StartCoroutine(GenerateColumnUpwards(new Vector2(maxRows, 0), maxColumns));
            }
            yield return new WaitForSeconds(0.3f);
        }

        //Open the doors according to which rooms are adjacent to each room:
        for(int i = 0; i < generatedRooms.Count; i++)
        {
            generatedRooms[i].GetComponent<Room>().OpenDoorsToAdjacentRooms();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void GenerateStartAndEnd()
    {
        GameObject startRoom = Instantiate(startRoomPrefab, transform, true);
        startRoom.transform.position = new Vector3(0, 0, 0);
        
        generatedRooms.Add(startRoom);

        GameObject endRoom = Instantiate(endRoomPrefab, transform, true);
        endRoom.transform.position = new Vector3(maxRows, 0f, maxColumns) * roomLength;
    
        generatedRooms.Add(endRoom);
    }

    private GameObject GenerateRoom(Vector2 roomPosition)
    {
        GameObject newRoom = Instantiate(roomGenerationSet.GetRandomRoom(), transform, true);
        newRoom.transform.position = new Vector3(roomPosition.x, 0f, roomPosition.y) * roomLength;
        return newRoom;
    }

    private IEnumerator GenerateColumnUpwards(Vector2 startPos, int columnLength)
    {
        Vector2 spawnPos = startPos;

        for(int i = 0; i < columnLength; i++)
        {
            GameObject newRoom = GenerateRoom(spawnPos);
            generatedRooms.Add(newRoom);

            spawnPos.y += 1;

            yield return new WaitForSeconds(0.1f);
        }
        
    }

}
