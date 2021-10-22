using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Stat
{
    private readonly List<StatModifier> _modifiers;
    private float _value;

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
