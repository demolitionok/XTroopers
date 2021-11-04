using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatContainer))]
public class PlayerHpContainer : HpContainer
{
    private PlayerStatContainer _playerStatContainer;


    protected override void Awake()
    {
        _playerStatContainer = GetComponent<PlayerStatContainer>();
    }

    protected void Start()
    {
        SetHp(startHp + _playerStatContainer.vitality.GetValue());
    }
}
