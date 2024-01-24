using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

[System.Serializable]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Health enemyHealth;

    private int damage;

    public int Damage { get { return damage; } }

    public Health EnemyHealth { get { return enemyHealth; } }

    public void Initialize(int initialHealth, int initialDamage)
    {
        enemyHealth = new Health(initialHealth);
        damage = initialDamage;
    }

    public void TakeDamage(int amount)
    {
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
        Destroy(gameObject);
    }
}


