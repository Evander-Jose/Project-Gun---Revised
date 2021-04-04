using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarker : MonoBehaviour
{
    public GameObject hitMarkerObject;
    public float lifetime;

    private void TurnOnHitMarker(Vector3 pointDir)
    {
        hitMarkerObject.SetActive(true);
        hitMarkerObject.transform.up = pointDir;
        Invoke("TurnOffHitMarker", lifetime);
    }

    private void TurnOffHitMarker()
    {
        hitMarkerObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Tracer collision!");
        Vector3 pointingDirection = collision.GetContact(0).normal;
        TurnOnHitMarker(pointingDirection);
    }
}
