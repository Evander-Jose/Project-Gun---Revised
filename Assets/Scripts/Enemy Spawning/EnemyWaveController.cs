using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyWaveController : MonoBehaviour
{
    public List<EnemyWave> enemyWaves = new List<EnemyWave>();
    public UnityEvent onBegin;
    public UnityEvent onEnd;
    public bool battleOngoing;
    [SerializeField] private int currentWave = 0;
    [Space]
    public bool cleared;
    private bool atLastWave = false;

    private void ActivateWave(int waveIndex)
    {
        enemyWaves[currentWave].ActivateEnemies();
    }

    private void SetNextIndex()
    {
        int output = currentWave + 1;

        //If output exceeds the max index; already at the last wave:
        if (output > enemyWaves.Count)
        {
            currentWave = enemyWaves.Count -1;
        }
        else
        {
            currentWave = output;
        }
    }

    private void ActivateNextWave()
    {
        SetNextIndex();
        ActivateWave(currentWave);
    }

    public void BeginBattle()
    {
        if (battleEnded == true) return;

        currentWave = 0;
        ActivateWave(currentWave);
        battleOngoing = true;
        onBegin.Invoke();
    }

    public void EndBattle()
    {
        onEnd.Invoke();
        battleOngoing = false;
    }

    bool battleEnded = false;

    private void Update()
    {
        atLastWave = (currentWave >= enemyWaves.Count - 1);
        Debug.Log("At last wave: " + atLastWave);

        if (enemyWaves[currentWave].EnemyLow() == true && atLastWave == false && battleOngoing == true)
        {
            ActivateNextWave();
        }

        if(enemyWaves[currentWave].EnemiesAlive() == 0 && atLastWave == true)
        {
            if (!battleEnded)
            {
                battleEnded = true;
                EndBattle();
            }
        }
    }
}
