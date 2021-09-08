using System;
using UnityEngine;

[RequireComponent(typeof(DamageDealer))]
public class MissleLauncher : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject rocket;
    [SerializeField] private Transform rocketPosition;
    private IDamageDealer _damageDealer;
        
    private void Awake()
    {
        _damageDealer = GetComponent<IDamageDealer>();
    }

    public void OpenFire(Transform target)
    {
        Instantiate(rocket, rocketPosition.position, Quaternion.identity);
        AntiTankRocket activeRocket = rocket.GetComponent<AntiTankRocket>();
        activeRocket.InitBullet(_damageDealer, target, true);
    }
}
