using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyBaseBehavior))]
[RequireComponent(typeof(ProjectileLauncher))]
[RequireComponent(typeof(NavMeshAgent))]
public class ProjectileLaunchEnemy : MonoBehaviour
{
    private EnemyBaseBehavior baseBehavior;
    private ProjectileLauncher projectileLauncher;
    private NavMeshAgent agent;

    private float timeSinceLastAttack_insideRange = 0f;
    private float timeSinceLastAttack_outsideRange = 0f;
    
    public GameObject projectilePrefab;
    [Space]
    [Header("Projectile Launch Settings")]
    public float straightLaunchSpeed = 5f;
    public float lobPower = 10f;
    public float lobHeight = 50f;
    [Space]
    public float attackDelay_inRange = 2f;
    public float attackDelay_outRange = 5f;
    [Space]
    public Transform launchLocation;

    private void Start()
    {
        projectileLauncher = GetComponent<ProjectileLauncher>();
        baseBehavior = GetComponent<EnemyBaseBehavior>();
        agent = GetComponent<NavMeshAgent>();

        baseBehavior.behaviorWhileInRange += StraightLaunch;
        baseBehavior.behaviorWhilePlayerOutOfRange += ChaseAndLob;
    }

    private void StraightLaunch()
    {
        agent.isStopped = true;
        if(timeSinceLastAttack_insideRange > attackDelay_inRange)
        {
            //launch projectile when the internal timer is more than the attack delay:
            projectileLauncher.LaunchProjectile(projectilePrefab, DirectionToPlayer(), straightLaunchSpeed, launchLocation.position);
            timeSinceLastAttack_insideRange = 0f;
        } else
        {
            timeSinceLastAttack_insideRange += Time.deltaTime;
        }

        timeSinceLastAttack_outsideRange += Time.deltaTime;
    }

    private void ChaseAndLob()
    {
        timeSinceLastAttack_insideRange += Time.deltaTime;

        //Sets up the navmesh agent so that it would chase the player:
        agent.SetDestination(baseBehavior.PlayerTransform.position);
        agent.isStopped = false;

        if(timeSinceLastAttack_outsideRange > attackDelay_outRange)
        {
            //Lob a projectile after a certain amount of seconds:
            projectileLauncher.ParabolaLaunchProjectile(projectilePrefab, DirectionToPlayer(), lobHeight, lobPower, launchLocation.position);
            timeSinceLastAttack_outsideRange = 0f;
        } else
        {
            timeSinceLastAttack_outsideRange += Time.deltaTime;
        }

    }

    private Vector3 DirectionToPlayer()
    {
        Vector3 output = baseBehavior.PlayerTransform.position - transform.position;
        return output;
    }
}
