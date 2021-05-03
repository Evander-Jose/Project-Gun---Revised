using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public void LaunchProjectile(GameObject projectilePrefab, Vector3 direction, float speed, Vector3 startPos)
    {
        GameObject newProj = Instantiate(projectilePrefab);
        newProj.transform.position = startPos;
        Rigidbody rigidbody = newProj.GetComponent<Rigidbody>();

        rigidbody.velocity = direction.normalized * speed;
    }

    public void ParabolaLaunchProjectile(GameObject projectilePrefab, Vector3 direction, float launchHeight, float launchForce, Vector3 startPos)
    {
        GameObject newProj = Instantiate(projectilePrefab);
        newProj.transform.position = startPos;
        Rigidbody rigidbody = newProj.GetComponent<Rigidbody>();

        Vector3 resultantDir = direction.normalized * launchForce + Vector3.up * launchHeight;
        rigidbody.AddForce(resultantDir, ForceMode.Impulse);
    }
}
