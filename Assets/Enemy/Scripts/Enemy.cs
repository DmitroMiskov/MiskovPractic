using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[System.Serializable]
public class Enemy
{
    [SerializeField]
    private float health;
    private float damage;

    public float Health { get { return health; } }

    public Enemy(float health, float damage)
    {
        this.health = health;
        this.damage = damage;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetDamage()
    {
        return damage;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        } 
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
    }
}


