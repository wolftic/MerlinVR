using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] _enemySpawnerObjects;
    private EnemySpawner[] _enemySpawners;
    private int _maxEnemies;

    private void Awake()
    {
        _enemySpawnerObjects = GameObject.FindGameObjectsWithTag("Spawner");
    }

    private void Start()
    {
        _maxEnemies = 15;
        _enemySpawners = new EnemySpawner[_enemySpawnerObjects.Length];

        for (var i = 0; i < _enemySpawners.Length; i++)
        {
            _enemySpawners[i] = _enemySpawnerObjects[i].GetComponent<EnemySpawner>();
        }

        SpawnEnemies(_maxEnemies);
    }

    private void Update()
    {
        // TotalEnemyCount() < 0 begin nieuwe ronde
        Debug.Log( TotalEnemyCount() );
    }

    private int TotalEnemyCount()
    {
        var c = 0;
        for (var i = 0; i < _enemySpawners.Length; i++)
        {
            c += _enemySpawners[i].EnemyCount();
        }

        return c;
    }

    private void SpawnEnemies(int count)
    {
        var countPerSpawner = count / _enemySpawners.Length;

        for (var i = 0; i < _enemySpawners.Length; i++)
        {
            _enemySpawners[i].SpawnEnemies(countPerSpawner);
        }
    }
}
