using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    private List<GameObject> childEnemies = new List<GameObject>();
    public int lowEnemyThreshold = 2;

    private void Awake()
    {
        childEnemies.Clear();
        foreach(Transform t in transform)
        {
            GameObject enemyComponent = t.GetComponent<GameObject>();
            childEnemies.Add(enemyComponent);
            t.gameObject.SetActive(false);
        }
    }

    public void ActivateEnemies()
    {
        foreach(GameObject e in childEnemies)
        {
            e.gameObject.SetActive(true);
        }
    }

    public int EnemiesAlive()
    {
        int output = 0;
        foreach(GameObject e in childEnemies)
        {
            if (e.gameObject.activeSelf == true)
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
            return true;
        } else
        {
            return false;
        }
    }
}
