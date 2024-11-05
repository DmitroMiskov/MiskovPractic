using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class WeaponSwitch : MonoBehaviour
{
    private IWeaponFactory weaponFactory;
    private IWeapon[] weapons = new IWeapon[3];
    private int currentWeaponIndex = 0;
    
    public GameObject weaponHolder;

    [Inject]
    public void Construct(IWeaponFactory weaponFactory)
    {
        this.weaponFactory = weaponFactory;
    }

    private void Start()
    {
        weapons[0] = weaponFactory.Create("Pixel-Pistol");


        for (int i = 0; i < weapons.Length; i++) 
        {
            if(weapons[i] == null)
            {
                weapons[i].GetGameObject().SetActive(false);
                weapons[i].GetGameObject().transform.parent = weaponHolder.transform;
            }
        }
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            SwitchWeapon((currentWeaponIndex + 1) % weapons.Length);
        }
        else if (scroll < 0f)
        {
            SwitchWeapon((currentWeaponIndex - 1 + weapons.Length) % weapons.Length);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && weapons.Length > 0)
        {
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && weapons.Length > 1)
        {
            SwitchWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.E) && pickupWeapon != null)
        {
            PickupWeapon();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IWeapon weapon = other.GetComponent<IWeapon>();
        if (weapon != null)
        {
            pickupWeapon = weapon;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        IWeapon weapon = other.GetComponent<IWeapon>();
        if (weapon != null && weapon == pickupWeapon)
        {
            pickupWeapon = null;
        }
    }

    private void PickupWeapon()
    {
        /*Destroy(weapons[currentWeaponIndex].GetGameObject());

        IWeapon createdWeapon = weaponFactory.Create();
        if (createdWeapon != null)
        {
            weapons[currentWeaponIndex] = createdWeapon;
            weapons[currentWeaponIndex].GetGameObject().SetActive(true);
        }
        else
        {
            Debug.LogError("Failed to create a new weapon after picking up.");
        }

        pickupWeapon = null;*/
    }

    private void SwitchWeapon(int index)
    {
        if (weapons[currentWeaponIndex] != null)
        {
            weapons[currentWeaponIndex].GetGameObject().SetActive(false);
        }

        currentWeaponIndex = index;
        if (weapons[currentWeaponIndex] != null)
        {
            weapons[currentWeaponIndex].GetGameObject().SetActive(true);
        }
        else
        {
            Debug.LogError("Weapon at index " + currentWeaponIndex + " is null.");
        }
    }
}
