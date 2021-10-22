using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HpContainer))]
public class DamageReceiver : MonoBehaviour, IDamageReceiver
{
    private HpContainer _hpContainer;
    public void Awake()
    {
        _hpContainer = GetComponent<HpContainer>();
    }

    public void ReceiveDamage(Damage damage)
    {
        _hpContainer.SetHp(_hpContainer.GetHp() - damage.DmgValue);
    }
}
