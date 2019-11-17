using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public float Rotation;
    public Vector3 Direction;
    private float _rightSide;
    private float _bottomSide;
    private float _leftSide;
    private float _topSide;

    void Start()
    {
        _rightSide = transform.position.x + transform.localScale.x / 2;
        _bottomSide = transform.position.z - transform.localScale.z / 2;
        _leftSide = transform.position.x - transform.localScale.x / 2;
        _topSide = transform.position.z + transform.localScale.z / 2;
    }

    public void Spawn(GameObject enemy)
    {
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(_leftSide, _rightSide), 0, Random.Range(_bottomSide, _topSide)), Quaternion.Euler(new Vector3 (0, Rotation, 0)));
        WalkThenRunScript enemyScript = newEnemy.GetComponent<WalkThenRunScript>();
        if (enemyScript != null)
        {
            enemyScript.setDirection(Direction);
        }
    }
}
