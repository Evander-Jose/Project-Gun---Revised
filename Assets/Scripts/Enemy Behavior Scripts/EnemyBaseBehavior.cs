using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseBehavior : MonoBehaviour
{
    //This is a script that all enemies in the game will have.

    //The main function of this script is to just execute delegates/events within state machines.

    //Initializing the delegates:

    //Maybe, when I have the time, I would implement much more complex behavior to the enemies.

    //public delegate void WhileHealthIsLow();
    //public event WhileHealthIsLow behaviorWhileHealthIsLow;

    public delegate void WhilePlayer_OutOfRange();
    public event WhilePlayer_OutOfRange behaviorWhilePlayerOutOfRange;

    public delegate void WhilePlayer_InRange();
    public event WhilePlayer_InRange behaviorWhileInRange;

    public enum EnemyState {OutsideRange, InsideRange}
    public EnemyState currentState;

    public float detectionDistance = 5f;

    private Transform playerTransform;
    public Transform PlayerTransform { get { return playerTransform;  } }

    private void Awake()
    {
        playerTransform = FindObjectOfType<PlayerWeaponControls>().transform;
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.OutsideRange:
                {
                    behaviorWhilePlayerOutOfRange?.Invoke();
                    break;
                }

            case EnemyState.InsideRange:
                {
                    behaviorWhileInRange?.Invoke();
                    break;
                }
        }

    }

    private void FixedUpdate()
    {
        float distanceFromPlayer = Vector3.Distance(playerTransform.position, transform.position);
        
        if(distanceFromPlayer >= detectionDistance)
        {
            currentState = EnemyState.InsideRange;
        } else
        {
            currentState = EnemyState.OutsideRange;
        }
    }
}
