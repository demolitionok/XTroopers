
using System.Collections.Generic;
using UnityEngine;

public class HeroFactory
{
    private HeroesPreset _preset;

    
    //TODO: won't work correctly because [var prefab] is reference to prefab and after method invocation these components WILL CHANGE
    private GameObject GetPrefabFromHero(Hero hero)
    {
        var prefab = _preset.GetPrefabByType(hero.type);
        prefab.GetComponent<PlayerXp>().LoadXp(hero.totalXp);
        
        prefab.GetComponent<PlayerStatContainer>().vitality = hero.statContainer.vitality;
        prefab.GetComponent<PlayerStatContainer>().accuracy = hero.statContainer.accuracy;
        prefab.GetComponent<PlayerStatContainer>().strength = hero.statContainer.strength;

        return prefab;
    }
}
