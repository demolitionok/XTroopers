using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Automatic Riffle Bullet
public class ARBullet : MonoBehaviour, IDamageDealer
{
    [SerializeField]
    private float dmgValue;

    public int allyLayer;

    public Damage DealDamage()
    {
        return new Damage
        {
            DmgValue = dmgValue
        };
    }

    private void OnCollisionEnter(Collision other)
    {
        var collisionGameObject = other.gameObject;
        if (collisionGameObject.TryGetComponent(out IDamageReceiver damageReceiver))
        {
            DamageService.TransferDamage(damageReceiver, this);
        }
        Destroy(gameObject);
    }
}
