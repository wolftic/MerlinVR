using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _spawner;
    private EnemySpawner _enemySpawner;
    private int _maxEnemies;


    private void Awake()
    {
        _enemySpawner = GetComponent<EnemySpawner>();
    }

    private void Start()
    {
        _maxEnemies = 1;
        _enemySpawner.SpawnEnemies(_maxEnemies);
    }

    private void Update()
    {

    }




}
