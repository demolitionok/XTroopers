using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Automatic Riffle Bullet
public class ARBullet : MonoBehaviour
{
    private IDamageDealer _damageDealer;
    private int _allyLayer;

    public void InitBullet(IDamageDealer damageDealer, int allyLayer)
    {
        _damageDealer = damageDealer;
        _allyLayer = allyLayer;
    }

    private void OnCollisionEnter(Collision other)
    {
        var collisionGameObject = other.gameObject;
        if (collisionGameObject.TryGetComponent(out IDamageReceiver damageReceiver))
        {
            DamageService.TransferDamage(damageReceiver, _damageDealer);
        }
        Destroy(gameObject);
    }
}
