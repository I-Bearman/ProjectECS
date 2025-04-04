using UnityEngine;
using Zenject;

public class PlayerStatsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IPlayerStats>().To<CharacterStats>().AsSingle();
    }
}