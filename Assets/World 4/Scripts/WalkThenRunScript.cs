using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkThenRunScript : MonoBehaviour
{
    public float Speed;
    public float RunSpeed;
    public Vector3 Direction;
    public TimeInterval timeIntervalToRun;
    private Rigidbody _rigidbody;
    private bool _run = false;
    private float _timeAfterToRun;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _timeAfterToRun = Time.time + UnityEngine.Random.Range(timeIntervalToRun.start, timeIntervalToRun.end);
    }

    void Update()
    {
        if (Time.time > _timeAfterToRun)
        {
            _run = true;
        }
    }

    void FixedUpdate()
    {  
        if (_run)
        {
            _rigidbody.MovePosition(_rigidbody.position + Direction * RunSpeed * Time.fixedDeltaTime);
        } else
        {
            Debug.Log(transform.rotation.eulerAngles);
            _rigidbody.MovePosition(_rigidbody.position + Direction * Speed * Time.fixedDeltaTime);
        }
    }

    [System.Serializable]
    public class TimeInterval
    {
        public float start;
        public float end;
    }
}

