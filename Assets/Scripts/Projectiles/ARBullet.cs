using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Automatic Riffle Bullet
public class ARBullet : Projectile
{
    private void OnCollisionEnter(Collision other)
    {
        var collisionGameObject = other.gameObject;
        var contactPoint = other.GetContact(0);
        PlayImpactEffect(contactPoint);
        
        if (collisionGameObject.TryGetComponent(out IDamageReceiver damageReceiver))
        {
            DamageService.TransferDamage(damageReceiver, _damageDealer);
        }
        Destroy(gameObject);
    }
}
