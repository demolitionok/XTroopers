using System;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    [SerializeField] private GameObject landMine;
    [SerializeField] private GameObject explosion;
    [SerializeField] private float damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.CompareTag("Enemy"))
        {
            explosion.SetActive(true);
            landMine.SetActive(false);
            // физический взрыв если нужно 
            // нанесение урона
            Destroy(gameObject, 1f);
        }
    }
}
