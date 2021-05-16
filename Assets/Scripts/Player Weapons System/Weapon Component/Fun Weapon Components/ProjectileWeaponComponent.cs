using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponComponent : WeaponComponent
{
    public ProjectileLauncher launcher;
    public GameObject projetileToLaunch;
    [Space]
    public float launchDelay;
    public float launchHeight;
    public float launchForce;
    public Transform muzzle;

    private float timeSinceLastLaunch = 0f;

    public override void ComponentOnCancel()
    {

    }

    public override void ComponentOnInvoked()
    {
        if (timeSinceLastLaunch > launchDelay)
        {
            timeSinceLastLaunch = 0f;
            launcher.ParabolaLaunchProjectile(projetileToLaunch, muzzle.forward, launchHeight, launchForce, muzzle.position);
        }
    }

    private void Update()
    {
        timeSinceLastLaunch += Time.deltaTime;
    }
}
