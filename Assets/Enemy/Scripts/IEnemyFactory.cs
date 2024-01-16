using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IEnemyFactory
{
    Enemy CreateEnemy(); 
}
