using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField] 
    protected GameObject impactEffect;

    protected Transform _target;
    protected IDamageProvider damageProvider;
    protected bool _launcherIsActive;

    public virtual void PlayImpactEffect(ContactPoint contactPoint)
    {
        Physics.Raycast(transform.position, transform.forward + transform.position, out RaycastHit hit, 1f);
        var impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        impact.transform.Rotate(new Vector3(90f, 0f, 0f));
    }

    public void InitProjectile(IDamageProvider damageProvider, Transform targetForRocket, bool launcherIsActive)
    {
        this.damageProvider = damageProvider;
        _target = targetForRocket;
        _launcherIsActive = launcherIsActive;
    }
}
