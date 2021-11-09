using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerHpContainer : HpContainer
{
    private PlayerStats _playerStats;


    protected override void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
    }

    protected void Start()
    {
        SetHp(startHp + _playerStats.vitality.GetValue());
    }
}
