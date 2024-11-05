using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerController : MonoBehaviour, IDamageable
{
    GamManager gameManager;
    public UnityEvent OnHealthChanged;

    private float maxHealth = 10f;
    private float currentHealth;

    public float RemainingHealthPercentage => currentHealth / maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public Vector2 TakeInput()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        return direction;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            PlayerDeadHandler();
        }
        UpdateHealthUI();
        OnHealthChanged.Invoke();
    }

    private void PlayerDeadHandler()
    {
        Debug.Log("Player is dead!");
        Destroy(gameObject);
        gameManager.GameOver();
    }

    private void UpdateHealthUI()
    {
        Debug.Log("Current Health: " + currentHealth + "/" + maxHealth);
    }
}
