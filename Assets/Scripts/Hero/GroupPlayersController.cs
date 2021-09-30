using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class GroupPlayersController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _maxGroup;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _anim;
    [SerializeField] private PhysicsMovement _mov;
    [SerializeField] private Rigidbody _rigidbody1;
    [SerializeField] private Animator _anim1;
    [SerializeField] private Transform _transform1;
    [SerializeField] private PhysicsMovement _mov1;
    [SerializeField] private Rigidbody _rigidbody2;
    [SerializeField] private Animator _anim2;
    [SerializeField] private Transform _transform2;
    [SerializeField] private PhysicsMovement _mov2;

    void Start()
    {
        
    }
    void Update()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, 0, _joystick.Vertical * _moveSpeed);
        _rigidbody1.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, 0, _joystick.Vertical * _moveSpeed);
        _rigidbody2.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, 0, _joystick.Vertical * _moveSpeed);
        _mov.Move(new Vector3(_joystick.Vertical * _moveSpeed, 0, _joystick.Horizontal * _moveSpeed));
        _mov1.Move(new Vector3(_joystick.Vertical * _moveSpeed, 0, _joystick.Horizontal * _moveSpeed));
        _mov2.Move(new Vector3(_joystick.Vertical * _moveSpeed, 0, _joystick.Horizontal * _moveSpeed));
        if (_joystick.Horizontal !=0 || _joystick.Vertical !=0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _transform1.rotation = Quaternion.LookRotation(_rigidbody1.velocity);
            _transform2.rotation = Quaternion.LookRotation(_rigidbody2.velocity);
            _anim.SetBool("isRun", true);
            _anim1.SetBool("isRun", true);
            _anim2.SetBool("isRun", true);
        }
        else
        {
            _anim.SetBool("isRun", false);
            _anim1.SetBool("isRun", false);
            _anim2.SetBool("isRun", false);
        }
    }
}
