using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileBehavior))]
public class DamageProjectile : MonoBehaviour
{
    private ProjectileBehavior projectileBehavior;
    public float damageAmount;

    private void Start()
    {
        projectileBehavior = GetComponent<ProjectileBehavior>();
        projectileBehavior.onProjectileTriggerEnter += DamageOther;
    }

    private void DamageOther(GameObject other)
    {
        Health healthComponent = other.GetComponent<Health>();
        if (healthComponent != null)
        {
            healthComponent.DealDamage(damageAmount);
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
