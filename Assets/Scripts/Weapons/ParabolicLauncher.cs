using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicLauncher : AbstractWeapon
{
    protected override void SpawnBullet(Transform target)
    {
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
        var activeRocket = projectile.GetComponent<Projectile>();
        var rigidbody = projectile.GetComponent<Rigidbody>();
        
        rigidbody.AddForce(projectileSpeed * shootingPoint.forward, ForceMode.Impulse);
        activeRocket.InitProjectile(damageProvider, target);
    }
}
