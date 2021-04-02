using System.Collections;
using UnityEngine;


public class Gun : Weapon
{
    public GunSettings gunSetting;
    [Space]
    public Transform firstPersonCamera;
    public LayerMask targetLayerMask;

    private float timeSinceLastFire = 0f;
    private bool canFire = true;

    public override GameObject GetTarget()
    {
        if (canFire == false) return null;

        timeSinceLastFire = 0f;

        RaycastHit rayHit;
        Ray gunRay = new Ray(transform.position, firstPersonCamera.transform.forward);

        Debug.DrawRay(transform.position, firstPersonCamera.transform.forward * 10f, Color.red, 5f);

        if (Physics.Raycast(gunRay, out rayHit, gunSetting.range, targetLayerMask))
        {
            return rayHit.collider.gameObject;
        } else
        {
            return null;
        }
    }

    public override void InflictDamageToTarget(Health other)
    {
        other.DealDamage(gunSetting.damage);
    }

    private void Update()
    {
        timeSinceLastFire += Time.deltaTime;
        if (timeSinceLastFire > (1f / gunSetting.fireRate))
        {
            canFire = true;
        }
        else
        {
            canFire = false;
        }
    }
}
