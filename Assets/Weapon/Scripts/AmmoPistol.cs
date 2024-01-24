using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;


public class AmmoPistol : MonoBehaviour
{
    public float speed;
    public float destroyTime;

    public int damage = 20;

    void Start()
    {
        Invoke("DestroyAmmo", destroyTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void DestroyAmmo()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null) 
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
