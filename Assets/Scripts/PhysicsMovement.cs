//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SurSlider _surSlider;
    [SerializeField] private Rigidbody _rigidbody;

    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = _surSlider.Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);
        _rigidbody.MovePosition(_rigidbody.position + offset);
    }
}
