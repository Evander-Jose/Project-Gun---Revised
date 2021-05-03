using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public delegate void OnProjectileCollide(GameObject other);
    public event OnProjectileCollide onProjectileCollision;

    public delegate void OnProjectileTrigggerEnter(GameObject other);
    public event OnProjectileTrigggerEnter onProjectileTriggerEnter;

    private void OnCollisionEnter(Collision collision)
    {
        onProjectileCollision?.Invoke(collision.transform.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        onProjectileTriggerEnter?.Invoke(other.gameObject);
    }
}
