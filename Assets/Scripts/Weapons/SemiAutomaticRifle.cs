using System;
using UnityEngine;


public class SemiAutomaticRifle : AbstractWeapon
{
    protected override void SpawnBullet(Transform target)
    {
        var projectileObject = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
        var projectile = projectileObject.GetComponent<Projectile>();
        
        projectile.InitProjectile(damageProvider, null);
        SetProjectileSpeed(projectileObject);
        Destroy(projectileObject, 3f);
    }

    private void SetProjectileSpeed(GameObject projectileObject)
    {
        projectileObject.GetComponent<Rigidbody>().velocity = projectileObject.transform.forward * weaponConfig.GetProjectileSpeed();
    }
}
