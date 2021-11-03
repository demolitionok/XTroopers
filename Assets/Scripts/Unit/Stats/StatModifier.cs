using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatModifier
{
    private readonly float _value;

    public float GetValue() => _value;

    public StatModifier()
    {
        _value = 1f;
    }

    public StatModifier(float val)
    {
        _value = val;
    }
}
