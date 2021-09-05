using UnityEngine;

public class SemiAutomaticRifle : MonoBehaviour,IWeapon
{

    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float speed;
    
    public int allyLayer;

    public void OpenFire(Transform target)
    {
        GameObject bullet =
            Instantiate(projectilePrefab, attackPoint.position,
                Quaternion.identity);
        bullet.GetComponent<ARBullet>().allyLayer = allyLayer;
        bullet.GetComponent<Rigidbody>().velocity = attackPoint.forward * speed;
        Destroy(bullet, 3f);
    }
}
