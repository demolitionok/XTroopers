using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamageDealer
{
    [SerializeField]
    private float dmgValue;
    
    public Damage GetDamage()
    {
        return new Damage
        {
            DmgValue = dmgValue
        };
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out IDamageReceiver damageReceiver))
        {
            DamageService.DealDamage(damageReceiver, this);
        }
    }
}
