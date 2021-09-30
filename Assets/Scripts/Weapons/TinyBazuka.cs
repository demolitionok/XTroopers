using UnityEngine;

public class TinyBazuka : AbstractWeapon
{
    [SerializeField] private Rigidbody bulletPrefab;
    private bool _readyToShoot;
    
    
    private void Awake()
    {
        flash.SetActive(false);
    }
    
    protected override void SpawnBullet(Transform target)
    {
        transform.LookAt(target);
        if(flash != null)
            flash.SetActive(true);
        Rigidbody bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        bullet.AddForce(shootingPoint.forward * projectileSpeed, ForceMode.Impulse);
        Invoke(nameof(FlashController),0.5f);
        
    }

}
