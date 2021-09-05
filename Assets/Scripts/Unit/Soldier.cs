using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : AbstractUnit, IDamageReceiver, IDamageDealer
{
    [SerializeField]
    private float dmgValue;
    
    public Damage DealDamage()
    {
        return new Damage
        {
            DmgValue = dmgValue
        };
    }
    
    public void ReceiveDamage(Damage damage)
    {
        SetHp(GetHp() - damage.DmgValue);
    }
}
