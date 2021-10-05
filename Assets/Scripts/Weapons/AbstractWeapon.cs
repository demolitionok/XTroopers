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
    private float shotCooldown;
    [SerializeField]
    protected Transform shootingPoint;
    [SerializeField]
    protected float projectileSpeed;
    [SerializeField]
    protected ParticleSystem flash;
    
    protected IDamageDealer _damageDealer;
    [SerializeField]
    protected float currentShotCooldown;

    private void Update()
    {
        currentShotCooldown -= Time.deltaTime;
    }

    private void Awake()
    {
        _damageDealer = GetComponent<DamageDealer>();
        currentShotCooldown = shotCooldown;
    }

    protected abstract void SpawnBullet(Transform target);

    public void OpenFire(Transform target)
    {
        if (currentShotCooldown >= 0) return;

        currentShotCooldown = shotCooldown;
        flash.Play();
        SpawnBullet(target);
    }
}
