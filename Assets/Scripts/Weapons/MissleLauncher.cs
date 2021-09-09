using System;
using UnityEngine;

[RequireComponent(typeof(DamageDealer))]
public class MissleLauncher : AbstractWeapon
{
    public override void OpenFire(Transform target)
    {
        GameObject rocket = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);
        AntiTankRocket activeRocket = rocket.GetComponent<AntiTankRocket>();
        activeRocket.InitBullet(_damageDealer, target, true);
    }
}
