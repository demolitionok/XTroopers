using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public readonly struct Damage
{
    public readonly float dmgValue;
    public readonly LayerMask enemyLayer;

    public Damage(float dmgValue, LayerMask enemyLayer)
    {
        this.dmgValue = dmgValue;
        this.enemyLayer = enemyLayer;
    }
}
