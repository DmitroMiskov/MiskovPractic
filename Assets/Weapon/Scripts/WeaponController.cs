using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponController : MonoBehaviour, IWeaponController
{
    private Weapon currentWeapon;
    
    public void ChangeWeapon<T>() where T : Weapon, new()
    {
        Destroy(currentWeapon);

        currentWeapon = gameObject.AddComponent<T>();
    }

    public void Shoot()
    {
        if(currentWeapon != null)
        {
            currentWeapon.Shoot();
        }
        else
        {
            Debug.LogWarning("No wepaon selected!");
        }
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        Destroy(currentWeapon);

        currentWeapon = newWeapon;
    }
}
