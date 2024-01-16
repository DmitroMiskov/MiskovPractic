using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    private IEnemyFactory _enemyFactory;
    
    

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform spawnPoint;

    [Inject]
    public void Construct(IEnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }

    private void Start()
    {
        
        StartCoroutine(StartSpawningEnemies());
    }

    private System.Collections.IEnumerator StartSpawningEnemies()
    {
        while (true)
        {
            SpawnAndAttackEnemy();
            yield return new WaitForSeconds(5f);
        }
    }

    public void SpawnAndAttackEnemy()
    {
        Enemy enemy = _enemyFactory.CreateEnemy();
        GameObject enemyGameObject = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        EnemyController enemyController = enemyGameObject.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.Initialize(enemy);
            Debug.Log("Enemy spawned with Health: " + enemy.GetHealth() + ", Damage: " + enemy.GetDamage());
            enemyController.Attack();
        }
        else
        {
            Debug.LogError("EnemyController not found on the spawned enemy!");
        }
    }
}
