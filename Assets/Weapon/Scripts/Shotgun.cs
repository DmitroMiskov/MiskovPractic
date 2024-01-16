using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shotgun : Weapon
{
    public Shotgun() : base(50f) { }

    public override void Shoot()
    {
        Debug.Log("Shotgun shooting with damage: " + GetDamage());
    }
}
