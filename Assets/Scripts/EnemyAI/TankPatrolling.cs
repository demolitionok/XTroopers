using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankPatrolling : MonoBehaviour
{
    [SerializeField]
    Transform point;

    private Vector3 startPos;
    private Vector3 endPos;
    
    private Vector3 currentTarget;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        startPos = gameObject.transform.position;
        endPos = point.position;
        currentTarget = endPos;
    }

    private void Start()
    {
        SetPointToMove();
    }

    private void SetPointToMove()
    {
        _agent.SetDestination(currentTarget);
    }

    private void Update()
    {
        if (_agent.remainingDistance < 1f)
        {
            currentTarget = Vector3.Distance(currentTarget, startPos) > Vector3.Distance(currentTarget, endPos)
                ? startPos
                : endPos;
            SetPointToMove();
        }
    }
}
