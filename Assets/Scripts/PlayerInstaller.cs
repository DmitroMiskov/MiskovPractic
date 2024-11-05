using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IMover>().To<PlayerMovement>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerController>().AsSingle();
        Container.Bind<IWeaponFactory>().To<WeaponFactory>().AsSingle();
        Container.Bind<GamManager>().AsSingle();
        
    }
}