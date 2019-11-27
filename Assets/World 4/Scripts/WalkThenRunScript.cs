using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkThenRunScript : MonoBehaviour, IEnemy
{
    public float Speed;
    public float RunSpeed;
    public TimeInterval timeIntervalToRun;
    private Vector3 _direction;
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
            _direction = Player.transform.position - transform.position;
            _direction = _direction / _direction.magnitude;
            transform.LookAt(Player.transform);
        }
    }

    void FixedUpdate()
    {  
        if (_run)
        {
            _rigidbody.MovePosition(_rigidbody.position + _direction * RunSpeed * Time.fixedDeltaTime);
        } else
        {
            _rigidbody.MovePosition(_rigidbody.position + _direction * Speed * Time.fixedDeltaTime);
        }
    }

    [System.Serializable]
    public class TimeInterval
    {
        public float start;
        public float end;
    }

    public void SetDirection (Vector3 direction)
    {
        _direction = direction;
    }
}

