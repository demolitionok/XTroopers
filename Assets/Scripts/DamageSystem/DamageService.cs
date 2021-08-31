using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageService
{
    public static void DealDamage(IDamageReceiver damageReceiver, IDamageDealer damageDealer)
    {
        damageReceiver.ReceiveDamage(damageDealer.GetDamage());
    }
}
