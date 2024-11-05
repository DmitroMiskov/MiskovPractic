using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour, IEnemyFactory
{
    [SerializeField]
    private GameObject[] enemyPrefabs;

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

    // Реалізація відсутнього методу з інтерфейсу
    public Enemy CreateEnemy()
    {
        // Вибрати випадковий індекс префабу
        int randomPrefabIndex = Random.Range(0, enemyPrefabs.Length);
        return CreateEnemy(randomPrefabIndex);
    }

    public Enemy CreateEnemy(int prefabIndex)
    {
        int randomPrefabIndex = Random.Range(0, enemyPrefabs.Length);
        int health = Random.Range(50, 100);
        int damage = Random.Range(10, 20);

        Enemy enemy = new Enemy();
        enemy.Initialize(health, damage, randomPrefabIndex);

        return enemy;
    }

    private void SpawnAndAttackEnemy()
    {
        // Виклик реалізованого методу
        Enemy enemy = CreateEnemy();
        GameObject enemyGameObject = Instantiate(enemyPrefabs[enemy.PrefabIndex], spawnPoint.position, Quaternion.identity);

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
