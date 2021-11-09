using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerDamageProvider : DamageProvider
{
    private PlayerStats _playerStats;
    private float _resultDmg;

    public override Damage GetDamage()
    {
        _resultDmg = dmgValue + _playerStats.strength.GetValue();
        return new Damage(_resultDmg, enemyLayer);
    }

    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
        _resultDmg = dmgValue + _playerStats.strength.GetValue();
    }
}
