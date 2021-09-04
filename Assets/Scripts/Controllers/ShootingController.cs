using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IWeapon))]
public class ShootingController : MonoBehaviour
{
    private bool _canShoot = true;
    
    private IWeapon _weapon;

    [SerializeField]
    private float shootCooldown;

    private float _currentShootCooldown;
    
    [SerializeField]
    private Transform _target;

    private void Awake()
    {
        _weapon = GetComponent<IWeapon>();
        _currentShootCooldown = shootCooldown;
    }

    private IEnumerator Shoot()
    {
        _canShoot = true;
        yield return new WaitForSeconds(3f);
        _canShoot = false;
    }

    private void ChooseTarget()
    {
        
    }

    private void Update()
    {
        _currentShootCooldown -= Time.deltaTime;
        if (_currentShootCooldown <= 0)
        {
            _weapon.OpenFire(_target);
            _currentShootCooldown = shootCooldown;
        }
    }
}
