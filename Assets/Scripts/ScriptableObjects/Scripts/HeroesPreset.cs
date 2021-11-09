using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "HeroesMap")]
public class HeroesPreset : ScriptableObject
{
    [SerializeField]
    private HeroPrefab[] heroPrefabs;

    public GameObject GetHeroPrefab(HeroType type)
    {
        foreach (var prefab in heroPrefabs)
        {
            var expectedPrefab = prefab.TryGetPrefab(type);
            if (expectedPrefab != null)
                return expectedPrefab;
        }

        Debug.LogError($"Prefab of {type} was not found, returned null");
        return null;
    }

    [Serializable]
    private struct HeroPrefab
    {
        [SerializeField]
        private HeroType type;
        [SerializeField]
        private GameObject prefab;
        
        public GameObject TryGetPrefab(HeroType type)
        {
            if (this.type == type)
            {
                return prefab;
            }

            return null;
        }
    }
}
