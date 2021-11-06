using System.Linq;

public class XpCalculator
{
    private readonly XpSystemConfig _xpSystemConfig;

    private int CalculateLevelXp(int totalXp)
    {
        var sum = Enumerable.Range(1, CalculateLevel(totalXp) - _xpSystemConfig.startLevel)
            .Aggregate(0, (a, b) => a + b);
        return totalXp - sum * _xpSystemConfig.xpForNextLvlGain;
    }
    public int GetLevelXp(int totalXp, int lvl)
    {
        var sum = Enumerable.Range(1, lvl - _xpSystemConfig.startLevel)
            .Aggregate(0, (a, b) => a + b);
        return totalXp - sum * _xpSystemConfig.xpForNextLvlGain;
    }

    public int CalculateXpForNextLevel(int totalXp) => _xpSystemConfig.initialXpForNextLevel + (CalculateLevel(totalXp) - _xpSystemConfig.startLevel) * _xpSystemConfig.xpForNextLvlGain;
    public int GetXpForNextLevel(int lvl) => _xpSystemConfig.initialXpForNextLevel + (lvl - _xpSystemConfig.startLevel) * _xpSystemConfig.xpForNextLvlGain;

    public int CalculateLevel(int totalXp)
    {
        var leftXp = totalXp;
        var newLevel = 0;
        var curLevelXp = _xpSystemConfig.initialXpForNextLevel;

        while (leftXp > curLevelXp)
        {
            leftXp -= curLevelXp;
            curLevelXp += _xpSystemConfig.xpForNextLvlGain;
            newLevel++;
        }

        return newLevel;
    }

    public XpCalculator(XpSystemConfig config)
    {
        _xpSystemConfig = config;
    }
}