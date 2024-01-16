using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Pistol : Weapon
{
    public Pistol() : base(20f) { }

    public override void Shoot()
    {
        Debug.Log("Pistol shooting with damage: " + GetDamage());
    }
}
