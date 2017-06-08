using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject[] _enemySpawnerObjects;
    private EnemySpawner[] _enemySpawners;
    private float _maxEnemies;
    private int _waveCount;
    private EnemySpawner _enemySpawner;
    private float _damage;
    public Canvas _canvas;
    public Text _waveText;
    public Text _enemyCountText;

    
    private void Awake()
    {
        _enemySpawnerObjects = GameObject.FindGameObjectsWithTag("Spawner");
        _enemySpawner = GetComponent<EnemySpawner>();
    }

    private void Start()
    {
        _waveCount = 1;
        _maxEnemies = 6;
        _damage = 1;
        _enemySpawners = new EnemySpawner[_enemySpawnerObjects.Length];
        
        for (var i = 0; i < _enemySpawners.Length; i++)
        {
            _enemySpawners[i] = _enemySpawnerObjects[i].GetComponent<EnemySpawner>();
        }

        SpawnEnemies(_maxEnemies, _damage);
        
        _waveText.text = "Wave: " + _waveCount;
      
        
        StartCoroutine(turnOffCanvas());
    }

    
    public IEnumerator turnOffCanvas()
    {
        yield return new WaitForSeconds(3f);
        _canvas.enabled = false;
    }
    
    private void Update()
    {
        TotalEnemyCount();
        CheckWave();
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
        _enemyCountText.text = "Enemy's: " + TotalEnemyCount().ToString();
        
        if (TotalEnemyCount() == 0)
        {
            Debug.Log("death");
            _damage *= 1.5f;
            _maxEnemies *= 1.5f;
            _enemyCountText.text = "Enemy's: " + TotalEnemyCount().ToString();
            _waveCount += 1;
            _waveText.text = "Wave: " + _waveCount;
            _canvas.enabled = true;
            Tower.Health = 100;
            SpawnEnemies(_maxEnemies, _damage);
            
            StartCoroutine(turnOffCanvas());
        }


    }

    private void SpawnEnemies(float count, float damage)
    {
       // _canvas.enabled = false;
        Debug.Log("spawing");
        var countPerSpawner = count / _enemySpawners.Length;

        for (var i = 0; i < _enemySpawners.Length; i++)
        {
            _enemySpawners[i].SpawnEnemies(countPerSpawner, damage);
        }
    }
}
