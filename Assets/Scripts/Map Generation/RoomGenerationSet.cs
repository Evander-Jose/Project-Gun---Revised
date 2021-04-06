using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Room Generation Set")]
public class RoomGenerationSet : ScriptableObject
{
    [Serializable]
    public class GeneratedRoom
    {
        public GameObject roomPrefab;
        [Range(0f, 1f)] public float probability;
    }

    public GeneratedRoom[] possibleRooms;

    public GameObject GetRandomRoom()
    {
        float roll = 0f;
        float totalRatio = 0f;

        foreach(GeneratedRoom gr in possibleRooms)
        {
            totalRatio += gr.probability;
        }

        roll = UnityEngine.Random.Range(0f, totalRatio);

        foreach(GeneratedRoom gr in possibleRooms)
        {
            if((roll -= gr.probability) <= 0)
            {
                return gr.roomPrefab;
            }
        }

        ///Only here to make the compiler shut up about 'not all code paths returning value':

        //This will only roll if the foreach loop above didn't successfully return anything
        int redundantRoll = UnityEngine.Random.Range(0, possibleRooms.Length - 1);
        Debug.LogWarning("Redundant room roll. Something's wrong with the probability function for room generation in RoomGenerationSet.cs.");
        return possibleRooms[redundantRoll].roomPrefab;
    }
}
