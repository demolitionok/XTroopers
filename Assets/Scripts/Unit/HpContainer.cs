using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StatContainer))]
public class HpContainer : MonoBehaviour
{
    [SerializeField]
    private StatContainer statContainer;
    
    
    [SerializeField]
    private float startHp;

    private float _hp;
    public UnityEvent OnDeath;
    public event Action<float> OnHpChanged;

    public void SetHp(float value)
    {
        _hp = value;
        OnHpChanged?.Invoke(value);
    }

    public void HpMinus(float value) => SetHp(GetHp() - value);

    private void CheckForDeath(float hp)
    {
        if (hp <= 0)
        {
            _hp = 0;
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }

    public float GetHp() => statContainer.vitality.GetValue() + _hp;

    private void OnEnable()
    {
        OnHpChanged += CheckForDeath;;
        SetHp(startHp);
    }

    private void OnDestroy()
    {
        OnHpChanged -= CheckForDeath;
    }

}
