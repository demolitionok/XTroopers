using UnityEngine;

public class XpBounty: MonoBehaviour, IXpProvider
{
    [SerializeField]
    private int xpBounty;

    public int GetTotalXp() => xpBounty;
}
