using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour, IDamageDealer
{
    [SerializeField]
    private float dmgValue;

    private Damage _damage;

    public Damage GetDamage() => _damage;

    public void Awake()
    {
        _damage = new Damage
        {
            DmgValue = dmgValue
        };
    }
}
