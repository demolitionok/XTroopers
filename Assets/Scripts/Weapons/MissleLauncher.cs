using System;
using UnityEngine;

[RequireComponent(typeof(DamageDealer))]
public class MissleLauncher : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform rocketPosition;
    private IDamageDealer _damageDealer;
        
    private void Awake()
    {
        _damageDealer = GetComponent<IDamageDealer>();
    }

    public void OpenFire(Transform target)
    {
        GameObject rocket = Instantiate(projectilePrefab, rocketPosition.position, Quaternion.identity);
        AntiTankRocket activeRocket = rocket.GetComponent<AntiTankRocket>();
        activeRocket.InitBullet(_damageDealer, target, true);
    }
}
