using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStats : MonoBehaviour
{
    public Stat vitality;
    public Stat accuracy;
    public Stat strength;

    public PlayerStats(Stat vitality, Stat accuracy, Stat strength)
    {
        this.vitality = vitality;
        this.accuracy = accuracy;
        this.strength = strength;
    }
}
