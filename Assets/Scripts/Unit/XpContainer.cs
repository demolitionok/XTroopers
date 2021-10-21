using System;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class XpContainer : MonoBehaviour
{
    [SerializeField]
    private int _initialXpForNextLevel = 100;
    [SerializeField]
    private int _startLevel = 1;
    
    private int _xpForNextLvlGain = 100;
    
    private int _totalXp;
    
    private int _cachedTotalXp;
    private int _cachedLevel;

    public UnityEvent<int> OnXpGain;
    public UnityEvent<int> OnLvlUp;
    
    private int GetLevelXp()
    {
        var sum = Enumerable.Range(1, GetLevel() - _startLevel).Aggregate(0,(a, b) => a + b);
        return _totalXp - sum * _xpForNextLvlGain;
    }
    private int GetXpForNextLevel() => _initialXpForNextLevel + (GetLevel() - _startLevel) * _xpForNextLvlGain;
    private int GetLevel() => _cachedTotalXp == _totalXp ? _cachedLevel : RecalculateLevel();
    private int RecalculateLevel()
    {
        var leftXp = _totalXp;
        var newLevel = 0;
        var curLevelXp = _initialXpForNextLevel;

        while (leftXp > curLevelXp)
        {
            leftXp -= curLevelXp;
            curLevelXp += _xpForNextLvlGain;
            newLevel++;
        }

        CacheLevel(newLevel);

        return newLevel;
    }
    private void CacheLevel(int newLevel)
    {
        _cachedTotalXp = _totalXp;
        _cachedLevel = newLevel;
    }

    private int GetXpBeforeNextLevel() => GetXpForNextLevel() - GetLevelXp();
    
    public void AddXp(int xpAmount)
    {
        var oldLevel = GetLevel();
        _totalXp += xpAmount;
        var newLevel = GetLevel();
        
        for (int level = oldLevel; level <= newLevel; level++)
            OnLvlUp.Invoke(newLevel);
        
        OnXpGain.Invoke(xpAmount);
    }
    

    private void Awake()
    {
    }
}
