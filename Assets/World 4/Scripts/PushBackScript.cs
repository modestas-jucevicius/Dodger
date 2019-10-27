using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBackScript : MonoBehaviour
{
    public GameObject Player;
    public float PushBackSpeed;
    private Rigidbody _rigidbody;
    private PlayerMovementControlScript _playerMovementControlScript;
    private Vector3 _inputs;

    void Start()
    {
        _rigidbody = Player.GetComponent<Rigidbody>();
        _playerMovementControlScript = Player.GetComponent<PlayerMovementControlScript>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Player && _rigidbody.velocity.magnitude < _playerMovementControlScript.Speed)
        {
            _inputs = _playerMovementControlScript.getInputs();
            if (_inputs != Vector3.zero)
            {
                _rigidbody.AddForce(-_inputs * PushBackSpeed, ForceMode.Impulse);
            }
        }
    }
}
