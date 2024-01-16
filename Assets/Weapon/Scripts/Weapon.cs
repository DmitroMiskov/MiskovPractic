using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class Weapon : MonoBehaviour
{
    private float damage;

    public Weapon(float damage)
    {
        this.damage = damage;
    }

    public abstract void Shoot();

    public float GetDamage()
    {
        return damage;
    }
}
