using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;

    public Enemy Enemy { get { return enemy; } }

    public float CurrentHealth
    {
        get { return enemy != null ? enemy.Health : 0f; }
    }

    public void Initialize(Enemy enemy) { this.enemy = enemy; }

    public void Attack()
    {
        Debug.Log("Enemy is attacking with damage: " + enemy.GetDamage());
    }

    public void TakeDamage(float amount)
    {
        enemy.TakeDamage(amount);
    }

    private void Die()
    {
        if(enemy.Health <= 0f)
        {
            Debug.Log("Enemy died!");
            Destroy(gameObject);
        }
    }
}
