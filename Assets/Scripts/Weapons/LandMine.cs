using System;
using UnityEngine;

public class LandMine : Projectile
{
    private void OnTriggerEnter(Collider other)
    {
        var collisionGameObject = other.gameObject;
        if (collisionGameObject.TryGetComponent(out IDamageReceiver damageReceiver))
        {
            impactEffect.SetActive(true);
            DamageService.TransferDamage(damageReceiver, damageProvider);
        }
        Destroy(gameObject, 1f);
    }
}
