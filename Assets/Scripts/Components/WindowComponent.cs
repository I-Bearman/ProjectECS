using UnityEngine;
using Zenject;

public class WindowComponent : MonoBehaviour
{
    [Inject]
    private GameConfigurations _gameConfigurations;

    void Start()
    {
        Screen.SetResolution(_gameConfigurations.width, _gameConfigurations.height, !_gameConfigurations.isWindowed);
        Debug.Log($"Screen Resolution is {Screen.width} x {Screen.height}");
    }
}
