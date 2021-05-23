using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPlayerHealth : MonoBehaviour
{
    public Health health;
    public FloatVariable playerHealthVariable;
    public FloatVariable maxPlayerHealthVariable;
    private void Update()
    {
        playerHealthVariable.Value = health.currentHealth;
        maxPlayerHealthVariable.Value = health.maxHealth;
    }
}
