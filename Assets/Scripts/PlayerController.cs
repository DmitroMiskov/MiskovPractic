using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour, IWeaponController
{
    private IWeaponController weaponController;

    [Inject]
    public void Construct(IWeaponController weaponController)
    {
        this.weaponController = weaponController;
    }

    private void Update()
    {
        HandleInput();
    }

    public void HandleInput()
    {
        if (weaponController != null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                weaponController.ChangeWeapon(new Pistol());
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                weaponController.ChangeWeapon(new Shotgun());
            }
            else if (Input.GetMouseButtonDown(0))
            {
                weaponController.Shoot();
            }
        }
        else
        {
            Debug.LogError("WeaponController is not initialized!");
        }
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        weaponController.ChangeWeapon(newWeapon);
    }

    public void Shoot()
    {
        weaponController.Shoot();
    }
}
