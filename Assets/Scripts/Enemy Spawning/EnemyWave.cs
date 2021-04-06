using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    private List<GameObject> childEnemies = new List<GameObject>();
    public int lowEnemyThreshold = 2; //The level of enemies at which the next wave will spawn.
    public bool activated = false;

    private void Awake()
    {
        childEnemies.Clear();
        foreach(Transform t in transform)
        {
            GameObject enemyComponent = t.gameObject;
            childEnemies.Add(enemyComponent);
            t.gameObject.SetActive(false);
        }
    }

    public void ActivateEnemies()
    {
        foreach(GameObject e in childEnemies)
        {
            activated = true;
            e.gameObject.SetActive(true);
        }
    }

    public int EnemiesAlive()
    {
        int output = 0;
        foreach(GameObject e in childEnemies)
        {
            if (e.gameObject.activeInHierarchy == true)
                output++;
            else
                continue;
        }

        return output;
    }

    public bool EnemyLow()
    {
        int currentEnemiesAlive = EnemiesAlive();
        if(currentEnemiesAlive <= lowEnemyThreshold)
        {
            Debug.Log(gameObject.name + " is low on enemies!");
            return true;
        } else
        {
            return false;
        }
    }
}
