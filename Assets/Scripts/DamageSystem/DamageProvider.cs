using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageProvider : MonoBehaviour, IDamageProvider
{
    [SerializeField]
    protected float dmgValue;
    [SerializeField]
    protected LayerMask enemyLayer;

    public virtual Damage GetDamage() => new Damage(dmgValue, enemyLayer);

}
