using UnityEngine;
using UnityEngine.Events;

public class EnemyScaner : MonoBehaviour
{
    private Collider[] _enemiesNearUnit = new Collider[7];
    private int _numColliders;
    private Transform _myTransform;
    [SerializeField] private float _shootingDistance;
    [SerializeField] private float _findEnemiesRadius;
    [SerializeField] private LayerMask whatIsEnemy;
    [HideInInspector] public Transform _currentEnemy;

    public UnityEvent<Transform> OnEnemyFind; 
    

    private void Awake()
    {
        _myTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        InvokeRepeating("FindEnemies",1f,2f);
    }

    private bool IsInView(GameObject obj)
    {
        if (Vector3.Distance(_myTransform.position, obj.transform.position) < _shootingDistance)
        {
            return true;
        }
        
        _currentEnemy = null;
        return false;
    }
    
    public void FindEnemies()
    {
        _numColliders = Physics.OverlapSphereNonAlloc(_myTransform.position, _findEnemiesRadius, _enemiesNearUnit,
            whatIsEnemy);
        for (int i = 0; i < _numColliders; ++i)
        {
            GameObject obj = _enemiesNearUnit[i].gameObject;
            if (IsInView(obj))
            {
                _currentEnemy = obj.transform;
                OnEnemyFind?.Invoke(_currentEnemy);
                
                break;
            }
        }
            
    }
}
