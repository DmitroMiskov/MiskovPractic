using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyFactory : IEnemyFactory
{
    public Enemy CreateEnemy()
    {
        float health = Random.Range(50f, 100f);
        float damage = Random.Range(10f, 20f);

        return new Enemy(health, damage);
    }
}
