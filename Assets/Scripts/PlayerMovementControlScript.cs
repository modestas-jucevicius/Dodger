using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControlScript : MonoBehaviour
{
    public float Speed;
    public Joystick Joystick;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Vector3 _inputs = Vector3.zero;
    private Quaternion _lookDirection;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _lookDirection = transform.rotation;
    }

    void Update()
    {
        _inputs.x = Joystick.Horizontal;
        _inputs.z = Joystick.Vertical;
        if (_inputs != Vector3.zero)
        {
            _animator.SetBool("Walking", true);
            _lookDirection = Quaternion.LookRotation(_inputs);
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookDirection, Speed * Time.deltaTime);
        } else
        {
            _animator.SetBool("Walking", false);
        }
    }

    void FixedUpdate()
    {
        if (_inputs != Vector3.zero)
        {
            _rigidbody.MovePosition(_rigidbody.position + _inputs * Speed * Time.fixedDeltaTime);
        }
    }

    public Vector3 getInputs()
    {
        return _inputs;
    }

}
