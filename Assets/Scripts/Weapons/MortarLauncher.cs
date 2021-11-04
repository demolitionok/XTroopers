using UnityEngine;
using Random = UnityEngine.Random;

public class MortarLauncher : AbstractWeapon
{
    [SerializeField] private float angleInDegrees = 45f;
    private float g = Physics.gravity.y;
    


    protected override void Update()
    {
        base.Update();
        shootingPoint.localEulerAngles = new Vector3(-angleInDegrees, 0f, 0f);
    }


    protected override void SpawnBullet(Transform target)
    {
        Transform currentEnemy = target;
        Vector3 fromTo = currentEnemy.position  - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0, fromTo.z);
        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);

        float x = fromToXZ.magnitude;
        float y = fromTo.y;
        float angleRadians = angleInDegrees * Mathf.PI / 180;
        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(angleRadians) * x) * Mathf.Pow(Mathf.Cos(angleRadians), Random.Range(1.97f,2.08f)));//p = 2
        float v = Mathf.Sqrt(Mathf.Abs(v2));
        GameObject newBullet = Instantiate(projectilePrefab, shootingPoint.position , Quaternion.identity);
        newBullet.GetComponent<Projectile>().InitProjectile(damageProvider, target);
        newBullet.GetComponent<Rigidbody>().velocity = shootingPoint.forward  * v;
    }
}
