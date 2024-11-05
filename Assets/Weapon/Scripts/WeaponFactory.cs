using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;


public class WeaponFactory : IWeaponFactory
{
    private DiContainer container;
    private string prefabPath = "Weapons/Prefabs/";

    public WeaponFactory(DiContainer container)
    {
        this.container = container;
    }

    public IWeapon Create(string weaponName)
    {
        GameObject prefab = Resources.Load<GameObject>(prefabPath + weaponName);
        if (prefab == null) 
        {
            Debug.Log("Префаб зброї не знайдено за адресою: " + prefabPath + weaponName);
            return null;
        }
        return container.InstantiatePrefabForComponent<IWeapon>(prefab);
    }
}
