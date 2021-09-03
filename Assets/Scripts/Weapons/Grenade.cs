using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private GameObject grenadePrefab;
    private int grenadeCount;
    [SerializeField] private Transform attackPoint;
    
    public void ThrowGrenade()
    {
        if (grenadeCount > 0)
        {
            var a = Instantiate(grenadePrefab, attackPoint.position, Quaternion.identity);
            a.GetComponent<Rigidbody>().AddForce(attackPoint.forward * 300);
            a.GetComponent<Rigidbody>().AddForce(attackPoint.up * 300);
            grenadeCount--;
        }
    }
}
