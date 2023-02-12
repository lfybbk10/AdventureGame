
using UnityEngine;
using Zenject;

public class GameServicesInstaller : MonoInstaller
{
    [SerializeField] private SaveTrigger _saveTrigger;
    public override void InstallBindings()
    {
        Container.Bind<MobileInputService>().AsSingle().NonLazy();
        Container.Inject(_saveTrigger);
    }
}
