using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTeleportToEnd : MonoBehaviour
{
    public Vector3 endCoordinates;
    public CharacterController playerController;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            playerController.transform.position = endCoordinates;
        }
    }
}
