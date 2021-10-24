using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDamageProvider))]
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
    
    protected IDamageProvider damageProvider;
    private float _currentShotCooldown;

    private void Update()
    {
        _currentShotCooldown -= Time.deltaTime;
    }

    private void Awake()
    {
        damageProvider = GetComponent<DamageProvider>();
        _currentShotCooldown = shotCooldown;
    }

    protected abstract void SpawnBullet(Transform target);

    public void OpenFire(Transform target)
    {
        if (_currentShotCooldown >= 0) return;

        _currentShotCooldown = shotCooldown;
        flash.Play();
        SpawnBullet(target);
    }
}
