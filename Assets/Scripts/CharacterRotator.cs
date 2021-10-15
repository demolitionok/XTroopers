using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    
    public void ChangeTarget(Transform target) => this.target = target;

    private void RotateToTarget()
    {
        gameObject.transform.LookAt(target);
    }

    private void Update()
    {
        if (target != null)
        {
            RotateToTarget();
        }
    }
}
