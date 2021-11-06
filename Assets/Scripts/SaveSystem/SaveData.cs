using System.Collections.Generic;

public struct SaveData
{
    public List<Hero> heroes;

    public SaveData(List<Hero> heroes)
    {
        this.heroes = heroes;
    }
}
