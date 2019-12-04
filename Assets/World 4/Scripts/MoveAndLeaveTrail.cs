using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndLeaveTrail : MonoBehaviour, IEnemy
{
    public float Speed;
    public float TimeBetweenTrailSpawns;
    public GameObject TrailingObject;
    private Vector3 _direction;
    private GameObject Player;
    private Rigidbody _rigidbody;
    private float _lastTrailSpawn = 0.0f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Time.time - _lastTrailSpawn > TimeBetweenTrailSpawns)
        {
            _lastTrailSpawn = Time.time;
            Instantiate(TrailingObject, new Vector3(_rigidbody.position.x, _rigidbody.position.y, _rigidbody.position.z), Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
         _rigidbody.MovePosition(_rigidbody.position + _direction * Speed * Time.fixedDeltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
