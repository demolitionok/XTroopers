using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageService
{
    public static void TransferDamage(IDamageReceiver damageReceiver, IDamageProvider damageProvider)
    {
        damageReceiver.ReceiveDamage(damageProvider.GetDamage());
    }
}
