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
    private int GetLevel()
    {
        if (_cachedTotalXp == _totalXp)
        {
            return _cachedLevel;
        }
        else
        {
            var leftXp = _totalXp;
            var newLevel = 0;
            var curLevelXp = _initialXpForNextLevel;
            
            while(leftXp > curLevelXp)
            {
                leftXp -= curLevelXp;
                curLevelXp += _xpForNextLvlGain;
                newLevel++;
            }

            _cachedLevel = newLevel;
            for (int level = _cachedLevel; level <= newLevel; level++)
            {
                OnLvlUp.Invoke(level);
            }

            _cachedTotalXp = _totalXp;
            
            return newLevel;
        }
    }
    private int GetXpBeforeNextLevel() => GetXpForNextLevel() - GetLevelXp();
    
    public void GainXp(int xpAmount)
    {
        _totalXp += xpAmount;//TODO: if level updates incorrectly invoke GetLevel here
        OnXpGain.Invoke(xpAmount);
    }
    

    private void Awake()
    {
    }
}
