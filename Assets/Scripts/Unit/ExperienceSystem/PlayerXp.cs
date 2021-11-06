using System;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PlayerXp : MonoBehaviour, IXpProvider, IXpReceiver
{
    [SerializeField]
    private XpSystemConfig _xpSystemConfig;

    private XpCalculator _calculator;
    
    private int _totalXp;
    
    private int _cachedTotalXp;
    private int _cachedLevel;

    private bool loaded = false;
    
    public UnityEvent<int> OnXpGain;
    public UnityEvent<int> OnLvlUp;

    private int GetLevelXp() => _calculator.GetLevelXp(_totalXp, GetLevel());
    private int GetXpForNextLevel() => _calculator.GetXpForNextLevel(GetLevel());
    private int GetLevel() => _cachedTotalXp == _totalXp ? _cachedLevel : RecalculateLevel();
    private int RecalculateLevel()
    {
        var newLevel = _calculator.CalculateLevel(_totalXp);
        CacheLevel(newLevel);

        return newLevel;
    }
    private void CacheLevel(int newLevel)
    {
        _cachedTotalXp = _totalXp;
        _cachedLevel = newLevel;
    }

    private int GetXpBeforeNextLevel() => GetXpForNextLevel() - GetLevelXp();
    
    public int GetTotalXp() => _totalXp;
    public void AddXp(int xpAmount)
    {
        var oldLevel = GetLevel();
        _totalXp += xpAmount;
        var newLevel = GetLevel();
        
        for (int level = oldLevel; level <= newLevel; level++)
            OnLvlUp.Invoke(newLevel);
        
        OnXpGain.Invoke(xpAmount);
    }

    public void LoadXp(int totalXp)
    {
        if (loaded == false)
        {
            _totalXp = totalXp;
        }
        else
        {
            throw new Exception("Trying to load xp second time!");
        }
        
        loaded = true;
    }

    private void Awake()
    {
        _calculator = new XpCalculator(_xpSystemConfig);
    }
}
