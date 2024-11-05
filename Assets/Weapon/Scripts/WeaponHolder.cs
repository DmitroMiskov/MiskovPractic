using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;
public class WeaponHolder : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;

    private IWeaponFactory weaponFactory;
    private IWeapon currentWeapon;

    [Inject]
    public void Construct(IWeaponFactory weaponFactory)
    {
        this.weaponFactory = weaponFactory;
    }

    private void Start()
    {
        CreateWeapon("Pixel-Pistol");
    }

    public void CreateWeapon(string weaponName)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.GetGameObject());
        }

        currentWeapon = weaponFactory.Create(weaponName);

        if (currentWeapon != null)
        {
            currentWeapon.GetGameObject().transform.parent = spawnPoint;
            currentWeapon.GetGameObject().transform.localPosition = Vector3.zero;
            currentWeapon.GetGameObject().SetActive(true);
        }
        else
        {
            Debug.LogError("Failed to create weapon.");
        }
    }
}

