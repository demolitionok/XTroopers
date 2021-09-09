using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField] 
    protected GameObject impactEffect;

    protected Transform _target;
    protected IDamageDealer _damageDealer;
    protected bool _launcherIsActive;
    
    public void InitProjectile(IDamageDealer damageDealer, Transform targetForRocket, bool launcherIsActive)
    {
        _damageDealer = damageDealer;
        _target = targetForRocket;
        _launcherIsActive = launcherIsActive;
    }
}
