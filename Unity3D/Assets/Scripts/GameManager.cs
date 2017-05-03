using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] _enemySpawnerObjects;
    private EnemySpawner[] _enemySpawners;
    private int _maxEnemies;
    private int _waveCount;
    private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _enemySpawnerObjects = GameObject.FindGameObjectsWithTag("Spawner");
        _enemySpawner = GetComponent<EnemySpawner>();
    }

    private void Start()
    {
        _waveCount = 0;
        _maxEnemies = 5;
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
        //Debug.Log( TotalEnemyCount() );
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

    private void CheckWave()
    {
        if (TotalEnemyCount() == 0)
        {
            _enemySpawner._enemyPrefab.GetComponent<EnemyAttack>().Damage += 5f;
        }


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
