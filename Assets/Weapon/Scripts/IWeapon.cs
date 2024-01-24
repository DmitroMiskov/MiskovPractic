using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public interface IWeapon
{
    void Shoot();
    void Reload();
    GameObject GetGameObject();
}

