using UnityEngine;
using Random = UnityEngine.Random;

public class MortarLauncher : MonoBehaviour , IWeapon
{
    [SerializeField] private float angleInDegrees = 45f;
    [SerializeField] private Transform mortarShootingPoint;
    [SerializeField] private Rigidbody bulletPrefab; 
    private float g = Physics.gravity.y;
    


    private void Update()
    {
        mortarShootingPoint.localEulerAngles = new Vector3(-angleInDegrees, 0f, 0f);
    }


    public void OpenFire(Transform target)
    {
        Transform currentEnemie = target;
        Vector3 fromTo = currentEnemie.position  - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0, fromTo.z);
        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);

        float x = fromToXZ.magnitude;
        float y = fromTo.y;
        float angleRadians = angleInDegrees * Mathf.PI / 180;
        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(angleRadians) * x) * Mathf.Pow(Mathf.Cos(angleRadians), Random.Range(1.97f,2.08f)));//p = 2
        float v = Mathf.Sqrt(Mathf.Abs(v2));
        Rigidbody newBullet = Instantiate(bulletPrefab, mortarShootingPoint.position , Quaternion.identity);
        newBullet.velocity = mortarShootingPoint.forward  * v;
    }
}
