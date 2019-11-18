using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] Spawners;
    public GameObject gameOverUI;
    public Round[] Rounds;
    public float TimeBetweenRounds;
    private SpawnScript[] _spawnScripts;
    private float _lastSpawn = 0;
    private bool _gameOver = false;
    private int _currentRound = 0;
    private float _roundStart = 0;
    private float _breakStart = 0;
    private bool _break = false;
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
        if (!_gameOver)
        {
            if (Time.time - _roundStart >= Rounds[_currentRound].RoundDuration)
            {
                if (!_break)
                {
                    _break = true;
                    _breakStart = Time.time;
                }

                if (Time.time - _breakStart >= TimeBetweenRounds)
                {
                    _break = false;
                    _currentRound++;
                    _roundStart = Time.time;
                }
            } else if (Time.time - _lastSpawn >= Rounds[_currentRound].SpawnTime)
            {
                _lastSpawn = Time.time;
                _spawnScripts[Random.Range(0, _spawnScripts.Length - 1)].Spawn(Rounds[_currentRound].GetSpawnEnemy());
            }
        }
        else if (_gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    public void GameOver()
    {
        _gameOver = true;
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    [System.Serializable]
    public class Round
    {
        public float SpawnTime;
        public Enemy[] Enemies;
        public float RoundDuration;

        public GameObject GetSpawnEnemy()
        {
            int randomizer = Random.Range(0, 100);
            for (int i = 0; i < Enemies.Length; i++)
            {
                if (Enemies[i].InsideSpawnInterval(randomizer)) {
                    return Enemies[i].EnemyObject;
                }
            }

            return null;
        }
    }

    [System.Serializable]
    public class Enemy
    {
        public int SpawnFrom;
        public int SpawnTo;
        public GameObject EnemyObject;

        public bool InsideSpawnInterval(int number)
        {
            return number >= SpawnFrom && number < SpawnTo;
        }
    }
}
