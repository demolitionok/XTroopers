using System;
using UnityEngine;

//[RequireComponent(typeof(IDamageDealer))]
public class SemiAutomaticRifle : MonoBehaviour,IWeapon
{

    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float speed;
    
    private IDamageDealer _damageDealer;
    private int _allyLayer;
    
    private void Awake()
    {
        _damageDealer = GetComponent<IDamageDealer>();
    }

    public void OpenFire(Transform target)
    {
        GameObject bullet =
            Instantiate(projectilePrefab, attackPoint.position,
                Quaternion.Euler(new Vector3(90f, 0, 0)));
        bullet.GetComponent<ARBullet>().InitBullet(_damageDealer, _allyLayer);
        bullet.GetComponent<Rigidbody>().velocity = attackPoint.forward * speed;
        Destroy(bullet, 3f);
    }
}
