using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Enemy _enemyPrefab;


    public void SpawnEnemies(int count)
    {
        var enemy = (Enemy) Instantiate(_enemyPrefab, transform.position, transform.rotation);
    }

}
