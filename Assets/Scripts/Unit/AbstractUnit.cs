using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractUnit : MonoBehaviour
{
    [SerializeField]
    private float _hp;
    public event Action OnDeath;
    
    protected void SetHp(float value)
    {
        _hp = value;
        if (value <= 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
            _hp = 0;
        }
    }

    public float GetHp() => _hp;
}
