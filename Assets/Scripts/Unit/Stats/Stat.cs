using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    private readonly List<StatModifier> _modifiers;
    [SerializeField]
    private float _value;

    public Stat(float value, List<StatModifier> modifiers)
    {
        _value = value;
        _modifiers = modifiers;
    }
    public Stat(float value)
    {
        _value = value;
        _modifiers = new List<StatModifier>();
    }
    public Stat()
    {
        _modifiers = new List<StatModifier>();
    }

    public float GetValue()
    {
        var result = _value;
        var totalModifier = 1f;
        foreach (var modifier in _modifiers)
        {
            totalModifier += modifier.GetValue() - 1f;
        }

        return result * totalModifier;
    }
    public void AddModifier(StatModifier statModifier) => _modifiers.Add(statModifier);
    public void RemoveModifier(StatModifier statModifier) => _modifiers.Remove(statModifier);
}
