using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Automatic Riffle Bullet
public class ARBullet : MonoBehaviour
{
    private IDamageDealer _damageDealer;
    
    public int allyLayer;


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
