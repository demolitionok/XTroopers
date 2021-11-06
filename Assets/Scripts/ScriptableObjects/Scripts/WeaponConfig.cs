using UnityEngine;

[CreateAssetMenu(menuName = "Configs/WeaponPreset")]
public class WeaponConfig : ScriptableObject
{
    [SerializeField]
    private float shotCooldown;
    [SerializeField]
    private float projectileSpeed;

    public float GetShotCooldown() => shotCooldown;
    public float GetProjectileSpeed() => projectileSpeed;
}
