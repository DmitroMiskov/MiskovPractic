using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyController : MonoBehaviour
{
    private Enemy enemy;

    public Enemy Enemy { get { return enemy; } }

    public float CurrentHealth
    {
        get { return enemy != null ? enemy.EnemyHealth.HealthEnemy : 0f; }
    }

    public void Initialize(Enemy enemy) { this.enemy = enemy; }

    public void Attack()
    {
        Debug.Log("Enemy is attacking with damage: " + enemy.Damage);
    }

    public void TakeDamage(int amount)
    {
        enemy.EnemyHealth.TakeDamage(amount);
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
