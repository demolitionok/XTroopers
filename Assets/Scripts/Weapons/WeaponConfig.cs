
using UnityEngine;

public class WeaponConfig : ScriptableObject
{
    private float shotCooldown;
    private float projectileSpeed;

    public float GetShotCooldown() => shotCooldown;
    public float GetProjectileSpeed() => projectileSpeed;
}
