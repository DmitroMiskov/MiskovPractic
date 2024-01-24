using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class WeaponSwitch : MonoBehaviour
{
    private IWeaponFactory weaponFactory;
    private IWeapon[] weapons = new IWeapon[2];
    private int currentWeaponIndex = 0;
    private IWeapon pickupWeapon;

    [Inject]
    public void Construct(IWeaponFactory weaponFactory)
    {
        this.weaponFactory = weaponFactory;
    }

    private void Start()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            IWeapon createdWeapon = weaponFactory.Create();

            if (createdWeapon != null)
            {
                weapons[i] = createdWeapon;
                weapons[i].GetGameObject().SetActive(false);
            }
            else
            {
                Debug.LogError("Failed to create weapon at index " + i);
            }
        }

        SwitchWeapon(0);
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll > 0f )
        {
            SwitchWeapon((currentWeaponIndex + 1) % weapons.Length);
        }
        else if( scroll < 0f )
        {
            SwitchWeapon((currentWeaponIndex - 1) % weapons.Length);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
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
        Destroy(weapons[currentWeaponIndex].GetGameObject());
        weapons[currentWeaponIndex] = pickupWeapon;
        weapons[currentWeaponIndex].GetGameObject().SetActive(true);
        pickupWeapon = null;
    }

    private void SwitchWeapon(int index)
    {
        if (weapons[currentWeaponIndex] != null)
        {
            weapons[currentWeaponIndex].GetGameObject().SetActive(false);
        }

        currentWeaponIndex = index;

        // Перевірте, чи новий об'єкт weapons[currentWeaponIndex] не є null
        if (weapons[currentWeaponIndex] != null)
        {
            weapons[currentWeaponIndex].GetGameObject().SetActive(true);
        }
        else
        {
            // Обробка помилки, якщо об'єкт weapons[currentWeaponIndex] має значення null
            Debug.LogError("Weapon at index " + currentWeaponIndex + " is null.");
        }
    }
}
