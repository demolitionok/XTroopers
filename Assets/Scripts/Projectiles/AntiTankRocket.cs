using UnityEngine;

public class AntiTankRocket : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    
    private Transform _targetForRocket;
    private IDamageDealer _damageDealer;
    private bool _launcherIsActive;
    
    public void InitBullet(IDamageDealer damageDealer, Transform targetForRocket, bool launcherIsActive)
    {
        _damageDealer = damageDealer;
        _targetForRocket = targetForRocket;
        _launcherIsActive = launcherIsActive;
    }
    
    void Update()
    {
        if (_launcherIsActive)
            StartRocketMove(_targetForRocket);
    }
    
    public void StartRocketMove(Transform target)
    {
        if (target != null)
        {
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, 0.5f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        var collisionGameObject = other.gameObject;
        if (collisionGameObject.TryGetComponent(out IDamageReceiver damageReceiver))
        {
            DamageService.TransferDamage(damageReceiver, _damageDealer);
        }
        Destroy(gameObject);
    }
}
