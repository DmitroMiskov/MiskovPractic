using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IWeaponController
{
    void ChangeWeapon(Weapon newWeapon);
    void Shoot();
}
