using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyBaseBehavior))]
[RequireComponent(typeof(Rigidbody))]
public class MeleeChaseBehavior : MonoBehaviour
{
    private EnemyBaseBehavior baseBehavior;

    public NavMeshAgent agent;
    public float movementSpeed;
    [Space]
    public float attackDelay;
    public float damageAmount;
    private Rigidbody rb;

    private float timeSinceLastAttack = 0f;

    private Health playerHealthComponent;

    private void Start()
    {
        baseBehavior = GetComponent<EnemyBaseBehavior>();
        baseBehavior.behaviorWhileInRange += AttackPlayer;
        baseBehavior.behaviorWhilePlayerOutOfRange += ChasePlayer;

        rb = GetComponent<Rigidbody>();
        playerHealthComponent = baseBehavior.PlayerTransform.GetComponent<Health>();
    }

    private void ChasePlayer()
    {
        agent.isStopped = false;
        if (agent.SetDestination(baseBehavior.PlayerTransform.position))
        {
            rb.velocity = agent.desiredVelocity * movementSpeed * Time.deltaTime;
        }

        timeSinceLastAttack += Time.deltaTime;
    }

    private void AttackPlayer()
    {
        agent.isStopped = true;
        if (timeSinceLastAttack > attackDelay)
        {
            timeSinceLastAttack = 0f;
            playerHealthComponent.DealDamage(damageAmount);
        }
        else
        {
            timeSinceLastAttack += Time.deltaTime;
        }
    }
}
