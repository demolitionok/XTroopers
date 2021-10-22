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

public class XpContainer : MonoBehaviour, IXpProvider, IXpReceiver
{
    [SerializeField]
    private XpSystemConfig _xpSystemConfig;
    
    private int _totalXp;
    
    private int _cachedTotalXp;
    private int _cachedLevel;

    public UnityEvent<int> OnXpGain;
    public UnityEvent<int> OnLvlUp;

    private int GetLevelXp()
    {
        var sum = Enumerable.Range(1, GetLevel() - _xpSystemConfig.startLevel).Aggregate(0,(a, b) => a + b);
        return _totalXp - sum * _xpSystemConfig.xpForNextLvlGain;
    }
    private int GetXpForNextLevel() => _xpSystemConfig.initialXpForNextLevel + (GetLevel() - _xpSystemConfig.startLevel) * _xpSystemConfig.xpForNextLvlGain;
    private int GetLevel() => _cachedTotalXp == _totalXp ? _cachedLevel : RecalculateLevel();
    private int RecalculateLevel()
    {
        var leftXp = _totalXp;
        var newLevel = 0;
        var curLevelXp = _xpSystemConfig.initialXpForNextLevel;

        while (leftXp > curLevelXp)
        {
            leftXp -= curLevelXp;
            curLevelXp += _xpSystemConfig.xpForNextLvlGain;
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
    
    private void Awake()
    {
    }
}
