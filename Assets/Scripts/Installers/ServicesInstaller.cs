
using UnityEngine;
using Zenject;

public class ServicesInstaller : MonoInstaller
{
    [SerializeField] private UpdateService _updateService;
    public override void InstallBindings()
    {
        Container.Bind<IUpdateService>().To<UpdateService>().FromInstance(_updateService).AsSingle().NonLazy();
        Container.Bind<MobileInputService>().AsSingle().NonLazy();
    }
}
