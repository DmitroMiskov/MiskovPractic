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
    private GameObject prefab;

    public WeaponFactory(DiContainer container)
    {
        this.container = container;
        prefab = Resources.Load<GameObject>("Weapons/Prefabs/Pixel-Pistol");
    }

    public IWeapon Create()
    {

        var weaponGameObject = container.InstantiatePrefabForComponent<IWeapon>(prefab);

        

        return weaponGameObject;
    }
}
