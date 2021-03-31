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

    public GameObject testRoomPrefab;
    [Space]
    public List<GameObject> rooms;

    private void Start()
    {
        StartCoroutine(GenerateRooms());
    }

    public IEnumerator GenerateRooms()
    {
        GenerateStartAndEnd();
        for(int i = 0; i < maxRows; i++)
        {
            StartCoroutine(GenerateColumnUpwards(new Vector2(i, 1), Random.Range(1, maxRows - 1)));
            yield return new WaitForSeconds(0.3f);
        }
        //Generate the last column:
        StartCoroutine(GenerateColumnUpwards(new Vector2(maxRows, 0), maxColumns));
    }

    private void GenerateStartAndEnd()
    {
        GameObject startRoom = Instantiate(testRoomPrefab, transform, true);
        startRoom.transform.position = new Vector3(0, 0, 0);

        rooms.Add(startRoom);

        GameObject endRoom = Instantiate(testRoomPrefab, transform, true);
        startRoom.transform.position = new Vector3(maxRows, 0f, maxColumns) * roomLength;

        rooms.Add(endRoom);
    }

    private GameObject GenerateRoom(Vector2 roomPosition)
    {
        GameObject newRoom = Instantiate(testRoomPrefab, transform, true);
        newRoom.transform.position = new Vector3(roomPosition.x, 0f, roomPosition.y) * roomLength;
        return newRoom;
    }

    private void GenerateColumn(Vector2 startPos,int columnLength)
    {
        //Choose a direction, up or downwards generation:
        if(Random.value >= 0.5f && (startPos.y + columnLength) <= maxColumns)
        {
            //Upwards generation
            StartCoroutine(GenerateColumnUpwards(startPos, columnLength));
        } 
        else if(Random.value < 0.5f && (startPos.y - columnLength) >= 0)
        {
            //Downwards generation
            StartCoroutine(GenerateColumnDownward(startPos, columnLength));
        }
    }

    private IEnumerator GenerateColumnDownward(Vector2 startPos, int columnLength)
    {
        Vector2 spawnPos = startPos;

        for(int i = 0; i < columnLength; i++)
        {
            GameObject newRoom = GenerateRoom(spawnPos);
            rooms.Add(newRoom);
            spawnPos.y--;

            yield return new WaitForSeconds(0.1f);
        }
        
    }

    private IEnumerator GenerateColumnUpwards(Vector2 startPos, int columnLength)
    {
        Vector2 spawnPos = startPos;

        for(int i = 0; i < columnLength; i++)
        {
            GameObject newRoom = GenerateRoom(spawnPos);
            rooms.Add(newRoom);
            spawnPos.y += 1;

            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
