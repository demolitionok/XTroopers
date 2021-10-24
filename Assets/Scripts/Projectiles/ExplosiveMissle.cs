using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveMissle : Projectile
{
    [SerializeField]
    private float explosionRadius;

    public void Explode()
    {
        var hitColliders = Physics.OverlapSphere(gameObject.transform.position, explosionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out IDamageReceiver damageReceiver))
            {
                DamageService.TransferDamage(damageReceiver, damageProvider);
            }
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        Explode();
        Destroy(gameObject);
    }
}
