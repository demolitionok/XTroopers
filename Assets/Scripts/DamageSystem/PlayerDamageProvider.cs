using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatContainer))]
public class PlayerDamageProvider : DamageProvider
{
    private PlayerStatContainer _playerStatContainer;

    public override Damage GetDamage()
    {
        return new Damage
        {
            DmgValue = base.GetDamage().DmgValue + _playerStatContainer.strength.GetValue()
        };
    }
}
