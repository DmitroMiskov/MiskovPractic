using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[System.Serializable]
public class Health
{
    [SerializeField]
    private int health;

    public float HealthEnemy { get { return health; } }

    public Health(int initialHealth)
    {
        health = initialHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
    }
}
