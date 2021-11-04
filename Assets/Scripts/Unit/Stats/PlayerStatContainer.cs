using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStatContainer : MonoBehaviour
{
    public Stat vitality;
    public Stat accuracy;
    public Stat strength;

    private void Awake()
    {
        vitality = new Stat();
        accuracy = new Stat();
        strength = new Stat();
    }
}
