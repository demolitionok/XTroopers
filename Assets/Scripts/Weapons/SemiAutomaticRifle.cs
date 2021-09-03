using UnityEngine;

public class SemiAutomaticRifle : MonoBehaviour,IWeapon
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float speed;
    
    public void OpenFire(Transform target)
    {
        GameObject bullet =
            Instantiate(projectilePrefab, attackPoint.position,
                Quaternion.identity); 
        bullet.GetComponent<Rigidbody>().velocity = attackPoint.forward * speed;
        Destroy(bullet, 3f);
    }
}
