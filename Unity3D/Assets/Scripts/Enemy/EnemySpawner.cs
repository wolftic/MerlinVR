using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;


    private void Start()
    {


    }

    public void SpawnEnemies(int count)
    {
        StartCoroutine(Spawn(count));
    }

    public IEnumerator Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var enemy = (GameObject) Instantiate(_enemyPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(7f);
        }
        yield break;
    }

}
