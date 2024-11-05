using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

[System.Serializable]
public class Enemy
{
    [SerializeField]
    private Health enemyHealth;

    private int prefabIndex;
    private int damage;

    public int Damage { get { return damage; } }
    public int PrefabIndex { get { return prefabIndex; } }

    public Health EnemyHealth { get { return enemyHealth; } }


    public void Initialize(int initialHealth, int initialDamage, int initialPrefabIndex)
    {
        enemyHealth = new Health(initialHealth);
        damage = initialDamage;
        prefabIndex = initialPrefabIndex;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log(enemyHealth.HealthEnemy + " " + amount);
        enemyHealth.TakeDamage(amount);
        CheckHealth();
        
    }

    public void Attack()
    {
        Debug.Log("Enemy is attacking with damage: " + Damage);
    }

    private void CheckHealth()
    {
        if (EnemyHealth.HealthEnemy <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        
    }
}


