using System;
using UnityEngine;

[RequireComponent(typeof(DamageDealer))]
public class MissleLauncher : AbstractWeapon
{
    public override void OpenFire(Transform target)
    {
        GameObject rocket = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);
        var activeRocket = rocket.GetComponent<Projectile>();
        activeRocket.InitProjectile(_damageDealer, target, true);
    }
}
