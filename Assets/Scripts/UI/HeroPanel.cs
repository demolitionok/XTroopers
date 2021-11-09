using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroPanel : MonoBehaviour
{
    [SerializeField]
    private HeroesPreset preset;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text xpText;
    [SerializeField]
    private Text classText;
    [SerializeField]
    private Text statsText;
    private Hero _hero;

    public void Init(Hero hero)
    {
        _hero = hero;
        InitText();
    }

    private void InitText()
    {
        nameText.text = $"{_hero.name}";
        xpText.text = $"XP: {_hero.totalXp}";
        classText.text = $"Class: {_hero.type}";
        statsText.text = $"Vitality: {_hero.stats.vitality.GetValue()} \n" +
                         $"Accuracy: {_hero.stats.accuracy.GetValue()} \n" +
                         $"Strength: {_hero.stats.strength.GetValue()}";
    }
}
