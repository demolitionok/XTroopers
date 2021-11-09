using UnityEngine;

public class HeroFactory
{
    private HeroesPreset _preset;
    
    private GameObject InstantiateHero(Hero hero)
    {
        var prefab = _preset.GetHeroPrefab(hero.type);
        var heroGameObject = Object.Instantiate(prefab);
        heroGameObject.GetComponent<PlayerXp>().LoadXp(hero.totalXp);
        
        heroGameObject.GetComponent<PlayerStats>().vitality = hero.stats.vitality;
        heroGameObject.GetComponent<PlayerStats>().accuracy = hero.stats.accuracy;
        heroGameObject.GetComponent<PlayerStats>().strength = hero.stats.strength;

        return heroGameObject;
    }
}
