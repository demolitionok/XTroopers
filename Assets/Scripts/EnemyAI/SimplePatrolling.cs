using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SimplePatrolling : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    [SerializeField] private float minMoveDistance;
    [SerializeField] private float maxMoveDistance;
    [SerializeField] private float moveDelay;
    

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating("MoveUnit",1f,moveDelay);
    }

    private Vector3 RandomNavSphere(float distance)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, distance, -1);
        return hit.position;
    }

    private void MoveUnit()
    {
        navMeshAgent.SetDestination(RandomNavSphere(Random.Range(minMoveDistance, maxMoveDistance)));
    }
}

