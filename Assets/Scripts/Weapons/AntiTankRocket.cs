using UnityEngine;

public class AntiTankRocket : MonoBehaviour
{
    [HideInInspector] public bool launcherIsActive ;
    [SerializeField] private GameObject explosion;
    public Transform targetForRocket;
    
    void Update()
    {
        if (launcherIsActive)
            StartRocketMove(targetForRocket);
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
}
