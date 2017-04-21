using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _cooldown = 2f;

    private void Start()
    {

    }

    public void SpawnEnemies(int count)
    {
        StartCoroutine(Spawn(count));
    }

    public IEnumerator Spawn(int count)
    {
        for (var i = 0; i < count; i++)
        {
            var enemy = (GameObject) Instantiate(_enemyPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(_cooldown);
        }
        yield break;
    }

}
