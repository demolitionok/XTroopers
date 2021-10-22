using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HpContainer : MonoBehaviour
{
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

    private void CheckForDeath(float hp)
    {
        if (hp <= 0)
        {
            _hp = 0;
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }

    public float GetHp() => _hp;

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
