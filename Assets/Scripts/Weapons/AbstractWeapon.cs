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
    protected WeaponConfig weaponConfig;
    [SerializeField]
    protected Transform shootingPoint;
    [SerializeField]
    protected ParticleSystem flash;
    
    protected IDamageProvider damageProvider;
    private float _currentShotCooldown;

    protected virtual void Update()
    {
        _currentShotCooldown -= Time.deltaTime;
    }

    private void Awake()
    {
        damageProvider = GetComponent<DamageProvider>();
        _currentShotCooldown = weaponConfig.GetShotCooldown();
    }

    protected abstract void SpawnBullet(Transform target);

    public void OpenFire(Transform target)
    {
        if (_currentShotCooldown >= 0) return;

        _currentShotCooldown = weaponConfig.GetShotCooldown();
        flash.Play();
        SpawnBullet(target);
    }
}
