using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatContainer))]
public class PlayerDamageProvider : DamageProvider
{
    private PlayerStatContainer _playerStatContainer;
    private float _resultDmg;

    public override Damage GetDamage()
    {
        _resultDmg = dmgValue + _playerStatContainer.strength.GetValue();
        return new Damage(_resultDmg, enemyLayer);
    }

    private void Awake()
    {
        _playerStatContainer = GetComponent<PlayerStatContainer>();
        _resultDmg = dmgValue + _playerStatContainer.strength.GetValue();
    }
}
