using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageDealer))]
public abstract class AbstractWeapon : MonoBehaviour, IWeapon
{
    [SerializeField]
    protected GameObject projectilePrefab;
    [SerializeField]
    protected float timeBetweenShots;
    [SerializeField]
    protected Transform shootingPoint;
    [SerializeField]
    protected float projectileSpeed;
    [SerializeField]
    protected GameObject flash;
    
    protected IDamageDealer _damageDealer;
    [SerializeField]
    protected float shotCooldown;

    private void Update()
    {
        shotCooldown -= Time.deltaTime;
    }

    private void Awake()
    {
        _damageDealer = GetComponent<DamageDealer>();
        shotCooldown = timeBetweenShots;
    }

    protected abstract void SpawnBullet(Transform target);

    public void OpenFire(Transform target)
    {
        if (shotCooldown <= 0)
        {
            shotCooldown = timeBetweenShots;
            SpawnBullet(target);
        }
    }

    protected virtual void FlashController()
    {
        if(flash != null)
            flash.SetActive(false);
    }
}
