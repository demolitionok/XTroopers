using UnityEngine;

public class AntiTankRocket : Projectile
{
    void Update()
    {
        if (_launcherIsActive)
            StartRocketMove(_target);
    }
    
    public void StartRocketMove(Transform target)
    {
        if (target != null)
        {
            transform.LookAt(target);
            var newPosition = Vector3.MoveTowards(transform.position, target.position, 0.01f);
            transform.position = newPosition;
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
