using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IMover>().To<PlayerMovement>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Player>().AsSingle();
        Container.Bind<PlayerController>().AsSingle();
    }
}