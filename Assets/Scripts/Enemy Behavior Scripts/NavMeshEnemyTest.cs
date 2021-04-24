using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemyTest : MonoBehaviour
{
    public NavMeshAgent agent;

    private PlayerWeaponControls playerObject;

    private void Start()
    {
        playerObject = FindObjectOfType<PlayerWeaponControls>();
    }

    private void Update()
    {
        agent.SetDestination(playerObject.transform.position);
    }
}
