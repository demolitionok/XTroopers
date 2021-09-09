using System;
using UnityEngine;


public class SemiAutomaticRifle : AbstractWeapon
{
    private void Awake()
    {
        _damageDealer = GetComponent<IDamageDealer>();
    }

    public override void OpenFire(Transform target)
    {
        GameObject projectileObject =
            Instantiate(projectilePrefab, attackPoint.position,
                Quaternion.Euler(new Vector3(90f, 0, 0)));
        var projectile = projectileObject.GetComponent<Projectile>();
        projectile.InitProjectile(_damageDealer, null, false);
        
        projectileObject.GetComponent<Rigidbody>().velocity = attackPoint.forward * bulletSpeed;
        Destroy(projectileObject, 3f);
    }
}
