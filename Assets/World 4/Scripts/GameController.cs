using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] Spawners;
    public float SpawnTime;
    public bool RandomizeSpawners;
    private SpawnScript[] _spawnScripts;
    private float _lastSpawn = 0;
    private int _lastSpawner = 0;
    void Start()
    {
        _spawnScripts = new SpawnScript[Spawners.Length];
        for (int i=0; i < Spawners.Length; i++)
        {
            _spawnScripts[i] = Spawners[i].GetComponent<SpawnScript>();
        }
    }

    void Update()
    {
        if (Time.time - _lastSpawn >= SpawnTime)
        {
            _lastSpawn = Time.time;
            if (RandomizeSpawners)
            {
                _spawnScripts[Random.Range(0, _spawnScripts.Length - 1)].Spawn(0);
            } else
            {
                _spawnScripts[(_lastSpawner + 1) % (_spawnScripts.Length - 1)].Spawn(0);
                _lastSpawner++;
            }
        }
    }
}
