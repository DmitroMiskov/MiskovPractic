using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{

    [Inject]
   

    private void Update()
    {
        HandleInput();
    }

    public void HandleInput()
    {
        /*if (weaponController != null)
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
        }*/
    }

   
}
