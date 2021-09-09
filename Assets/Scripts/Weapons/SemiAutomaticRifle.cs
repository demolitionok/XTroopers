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
        GameObject bullet =
            Instantiate(projectilePrefab, attackPoint.position,
                Quaternion.Euler(new Vector3(90f, 0, 0)));
        bullet.GetComponent<ARBullet>().InitBullet(_damageDealer);
        bullet.GetComponent<Rigidbody>().velocity = attackPoint.forward * bulletSpeed;
        Destroy(bullet, 3f);
    }
}
