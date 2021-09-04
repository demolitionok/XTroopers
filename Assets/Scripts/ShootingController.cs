using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IWeapon))]
public class ShootingController : MonoBehaviour
{
    private IWeapon _weapon;

    [SerializeField]
    private Transform _target;

    private void Awake()
    {
        _weapon = GetComponent<IWeapon>();
    }

    private IEnumerator Shoot()
    {
        _weapon.OpenFire(_target);
        yield return new WaitForSeconds(3f);
    }

    private void ChooseTarget()
    {
        
    }

    private void Update()
    {
        StartCoroutine(Shoot());
    }
}
