using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HpContainer : MonoBehaviour
{
    [SerializeField]
    protected float startHp;

    private float _hp;
    public UnityEvent OnDeath;
    public UnityEvent<float> OnHpChanged;

    protected void SetHp(float value)
    {
        _hp = value;
        OnHpChanged?.Invoke(value);
        CheckForDeath();
    }
    
    private float GetHp() => _hp;

    public void HpMinus(float value) => SetHp(GetHp() - value);

    private void CheckForDeath()
    {
        if (GetHp() <= 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }


    protected virtual void Awake()
    {
        SetHp(startHp);
    }
}
