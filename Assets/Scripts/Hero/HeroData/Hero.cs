using System;

[Serializable]
public class Hero
{
    public PlayerStats stats;
    public int totalXp;
    public string name;
    public HeroType type;

    public Hero(PlayerStats stats, int totalXp, string name, HeroType type)
    {
        this.stats = stats;
        this.totalXp = totalXp;
        this.name = name;
        this.type = type;
    }
}
