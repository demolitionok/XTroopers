using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AbstractUnit))]
public class DamageReceiver : MonoBehaviour, IDamageReceiver
{
    private AbstractUnit _hpContainer;
    public void Awake()
    {
        _hpContainer = GetComponent<AbstractUnit>();
    }

    public void ReceiveDamage(Damage damage)
    {
        _hpContainer.SetHp(_hpContainer.GetHp() - damage.DmgValue);
    }
}
