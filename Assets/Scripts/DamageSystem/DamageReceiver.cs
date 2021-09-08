using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AbstractUnit))]
public class DamageReceiver : MonoBehaviour, IDamageReceiver
{
    private AbstractUnit _selfUnit;
    public void Awake()
    {
        _selfUnit = GetComponent<AbstractUnit>();
    }

    public void ReceiveDamage(Damage damage)
    {
        _selfUnit.SetHp(_selfUnit.GetHp() - damage.DmgValue);
    }
}
