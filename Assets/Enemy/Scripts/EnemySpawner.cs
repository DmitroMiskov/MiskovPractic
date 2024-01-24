using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour, IEnemyFactory
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform spawnPoint;

    private void Start()
    {
        StartCoroutine(StartSpawningEnemies());
    }

    private IEnumerator StartSpawningEnemies()
    {
        while (true)
        {
            SpawnAndAttackEnemy();
            yield return new WaitForSeconds(5f);
        }
    }

    public Enemy CreateEnemy()
    {
        int health = Random.Range(50, 100);
        int damage = Random.Range(10, 20);

        Enemy enemy = new Enemy();
        enemy.Initialize(health, damage);

        return enemy;
    }

    private void SpawnAndAttackEnemy()
    {
        Enemy enemy = CreateEnemy();
        GameObject enemyGameObject = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        EnemyController enemyController = enemyGameObject.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.Initialize(enemy);
            Debug.Log("Enemy spawned with Health: " + enemy.EnemyHealth.HealthEnemy + ", Damage: " + enemy.Damage);
            enemyController.Attack();
        }
        else
        {
            Debug.LogError("EnemyController not found on the spawned enemy!");
        }
    }

}
