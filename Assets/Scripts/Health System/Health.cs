using System.Collections;
using UnityEngine;


public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public void DealDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0f)
            Destroy(gameObject);
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
}
