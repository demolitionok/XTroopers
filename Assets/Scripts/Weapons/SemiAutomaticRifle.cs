using System;
using UnityEngine;


public class SemiAutomaticRifle : AbstractWeapon
{
    protected override void SpawnBullet(Transform target)
    {
        GameObject projectileObject = Instantiate(projectilePrefab, attackPoint.position, attackPoint.rotation);
        var projectile = projectileObject.GetComponent<Projectile>();
        
        projectile.InitProjectile(_damageDealer, null, false);
        projectileObject.GetComponent<Rigidbody>().velocity = attackPoint.forward * bulletSpeed;
        Destroy(projectileObject, 3f);
    }
}
