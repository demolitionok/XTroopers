using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : AbstractUnit, IDamageReceiver
{
    public void ReceiveDamage(Damage damage)
    {
        SetHp(GetHp() - damage.DmgValue);
    }
}
