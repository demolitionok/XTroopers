using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour, IDamageReceiver
{
    [SerializeField]
    private float defence;
    [SerializeField]
    private float hp;

    public void ReceiveDamage(Damage damage)
    {
        hp = hp - (damage.DmgValue - defence);
    }
}
