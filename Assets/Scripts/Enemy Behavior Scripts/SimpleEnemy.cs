using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public Transform playerTransform;
    [Space]
    public CharacterController charController;
    public float moveSpeed;
    public float damage;
    public float attackRange;

    private Health playerHealth;
    private float timeSinceLastAttack = 0f;

    Vector3 moveDir = new Vector3();

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        playerHealth = playerTransform.GetComponent<Health>();
    }

    private void Update()
    {
        if (playerTransform == null) return;

        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer > attackRange)
        {

            //Move to the player (later versions would have a nav mesh agent):
            moveDir = playerTransform.position - transform.position;
            moveDir.Normalize();
            moveDir *= moveSpeed * Time.deltaTime;
            charController.Move(moveDir);       
        } else
        {
            if(timeSinceLastAttack > 2f)
            {
                timeSinceLastAttack = 0f;
                playerHealth.DealDamage(damage);
            }
        }

        timeSinceLastAttack += Time.deltaTime;
    }

    private void FixedUpdate()
    { 
        //Apply gravity cos :P
        if(charController.isGrounded == false) //The built in ground check should do just fine here.
        {
            //This will cause gravity to stack, but what do I care? This is a prototype enemy script anyway.
            moveDir.y -= 9.81f;
        }
    }
}
