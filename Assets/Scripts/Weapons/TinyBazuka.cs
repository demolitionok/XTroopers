using UnityEngine;

public class TinyBazuka : AbstractWeapon
{
    [SerializeField]
    private Rigidbody bulletPrefab;
    
    protected override void SpawnBullet(Transform target)
    {
        transform.LookAt(target);
        Rigidbody bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        bullet.AddForce(shootingPoint.forward * weaponConfig.GetProjectileSpeed(), ForceMode.Impulse);
    }

}
