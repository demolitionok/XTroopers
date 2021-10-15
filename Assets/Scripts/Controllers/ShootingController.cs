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
    private Transform _target;

    private void Awake()
    {
        _weapon = GetComponent<IWeapon>();
    }

    public void ChangeTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        _weapon.OpenFire(_target);
    }
}
