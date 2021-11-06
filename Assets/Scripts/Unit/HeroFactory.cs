using UnityEngine;

public class HeroFactory
{
    private HeroesPreset _preset;
    
    private GameObject InstantiateHero(Hero hero)
    {
        var prefab = _preset.GetPrefabByType(hero.type);
        var heroGameObject = Object.Instantiate(prefab);
        heroGameObject.GetComponent<PlayerXp>().LoadXp(hero.totalXp);
        
        heroGameObject.GetComponent<PlayerStatContainer>().vitality = hero.statContainer.vitality;
        heroGameObject.GetComponent<PlayerStatContainer>().accuracy = hero.statContainer.accuracy;
        heroGameObject.GetComponent<PlayerStatContainer>().strength = hero.statContainer.strength;

        return heroGameObject;
    }
}
