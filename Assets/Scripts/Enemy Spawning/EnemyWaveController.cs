using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyWaveController : MonoBehaviour
{
    private EnemyWave[] enemyWaves;
    public UnityEvent onBegin;
    public UnityEvent onEnd;
    public bool battleOngoing = false;
    [SerializeField] private int currentWave = 0;
    [Space]
    public bool cleared;

    private bool clearTriggered = false;

    private void Start()
    {
        enemyWaves = gameObject.GetComponentsInChildren<EnemyWave>();
    }

    private void Update()
    {
        if (battleOngoing == false || cleared == true)
            return;

        if (enemyWaves[currentWave].EnemyLow())
        {
            if (currentWave != enemyWaves.Length - 1)
            {
                //Activate the next enemy, up until the max index:
                currentWave++;
                enemyWaves[currentWave].ActivateEnemies();
            }
            else
            {
                //At this point of the code, currentWave must be the last index.
                if (enemyWaves[currentWave].EnemiesAlive() == 0)
                {
                    //If all the enemies of the last wave are dead,
                    cleared = true;
                }
            }   

        }

        if (cleared == true && clearTriggered == false)
        {
            clearTriggered = true;
            cleared = true;
            onEnd.Invoke();
        }


    }

    public void BeginBattle()
    {
        //To prevent double calls:
        if (battleOngoing == false && cleared == false)
            battleOngoing = true;
        else
            return;

        //Tell the first wave, that was being skipped, to activate as soon as battle starts:

        //at this point of the code, currentEnemies is most likely 0, so:
        enemyWaves[currentWave].ActivateEnemies();

        Debug.Log("battle begins!");
    }
}
