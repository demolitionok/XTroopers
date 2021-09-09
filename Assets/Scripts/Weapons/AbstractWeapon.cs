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
    protected Transform attackPoint;
    [SerializeField]
    protected float bulletSpeed;

    protected GameObject flash;
    
    protected IDamageDealer _damageDealer;

    private void Awake()
    {
        _damageDealer = GetComponent<DamageDealer>();
    }

    public abstract void OpenFire(Transform target);
    
    protected virtual void FlashController()
    {
        if(flash != null)
            flash.SetActive(false);
    }
}
