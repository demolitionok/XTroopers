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

    public virtual void PlayImpactEffect(ContactPoint contactPoint)
    {
        Physics.Raycast(transform.position, transform.forward + transform.position, out RaycastHit hit, 1f);
        Instantiate(impactEffect, hit.point, Quaternion.LookRotation(transform.forward + transform.position, hit.normal));
    }

    public void InitProjectile(IDamageDealer damageDealer, Transform targetForRocket, bool launcherIsActive)
    {
        _damageDealer = damageDealer;
        _target = targetForRocket;
        _launcherIsActive = launcherIsActive;
    }
}
