using System;
using UnityEngine;


public class SemiAutomaticRifle : AbstractWeapon
{
    protected override void SpawnBullet(Transform target)
    {
        GameObject projectileObject = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
        var projectile = projectileObject.GetComponent<Projectile>();
        
        projectile.InitProjectile(_damageDealer, null, false);
        projectileObject.GetComponent<Rigidbody>().velocity = projectileObject.transform.forward * projectileSpeed;
        Destroy(projectileObject, 3f);
    }
}
