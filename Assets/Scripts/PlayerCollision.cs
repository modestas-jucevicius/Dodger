using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject GameController;
    private GameController _gameControllerScript;
    public bool shieldActive = false;

    public void Start()
    {
        _gameControllerScript = GameController.GetComponent<GameController>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !shieldActive)
        {
            _gameControllerScript.GameOver();
            Destroy(gameObject);
        }
    }
}
