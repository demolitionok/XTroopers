using System;
using UnityEngine;

[RequireComponent(typeof(IDamageProvider))]
public class MissleLauncher : AbstractWeapon
{
    protected override void SpawnBullet(Transform target)
    {
        GameObject rocket = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
        var activeRocket = rocket.GetComponent<Projectile>();
        activeRocket.InitProjectile(damageProvider, target, true);
    }
}
