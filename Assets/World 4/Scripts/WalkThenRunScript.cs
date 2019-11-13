using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkThenRunScript : MonoBehaviour
{
    public float Speed;
    public float RunSpeed;
    public Vector3 Direction;
    public TimeInterval timeIntervalToRun;
    private GameObject Player;
    private Rigidbody _rigidbody;
    private bool _run = false;
    private float _timeAfterToRun;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
        _timeAfterToRun = Time.time + UnityEngine.Random.Range(timeIntervalToRun.start, timeIntervalToRun.end);
    }

    void Update()
    {
        if (_run == false && Time.time > _timeAfterToRun)
        {
            _run = true;
            Direction = Player.transform.position - transform.position;
            Direction = Direction / Direction.magnitude;
            transform.LookAt(Player.transform);
        }
    }

    void FixedUpdate()
    {  
        if (_run)
        {
            _rigidbody.MovePosition(_rigidbody.position + Direction * RunSpeed * Time.fixedDeltaTime);
        } else
        {
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

