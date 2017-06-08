using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject _enemyPrefab;
    [SerializeField] private float _cooldown = 2f;


    private List<GameObject> _enemies = new List<GameObject>();

    private void Awake()
    {

    }
    
    private void Start()
    {

    }

    public void SpawnEnemies(float count, float damage)
    {
        StartCoroutine(Spawn(count, damage));
    }

    public IEnumerator Spawn(float count, float damage)
    {
        _enemies.Clear();

        for (var i = 0; i < count; i++)
        {
            var enemy = (GameObject) Instantiate(_enemyPrefab, transform.position, transform.rotation);
            
            enemy.GetComponent<EnemyAttack>().Damage = damage;
            Debug.Log("Damage: " + damage);
            
            _enemies.Add(enemy);
            yield return new WaitForSeconds(_cooldown);
        }
       
    }

    public int EnemyCount()
    {
        var c = 0;

        for (var i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i] == null) continue;
            c++;
        }

        return c;
    }

}
