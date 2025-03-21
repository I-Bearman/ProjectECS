using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
    GameConfigurationsDummy configurationsDummy;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameConfigurations>().AsSingle();
        Container.Bind<GameConfigurationsDummy>().FromInstance(configurationsDummy);
    }
}

class GameConfigurationsDummy
{
    Screen.SetResolution(800, 600, false);
}