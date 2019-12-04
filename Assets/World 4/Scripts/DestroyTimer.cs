using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float TimeAlive;
    private float _destroyTime;

    void Start()
    {
        _destroyTime = Time.time;
    }

    void Update()
    {
        if (Time.time - _destroyTime > TimeAlive)
        {
            Destroy(gameObject);
        }
    }
}
