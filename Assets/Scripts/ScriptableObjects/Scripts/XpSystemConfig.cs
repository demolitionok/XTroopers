using UnityEngine;

[CreateAssetMenu(menuName = "Configs/XpSystem")]
public class XpSystemConfig : ScriptableObject
{
    public int initialXpForNextLevel = 100;
    public int startLevel = 1;
    public int xpForNextLvlGain = 100;
}