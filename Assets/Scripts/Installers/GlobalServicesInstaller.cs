
using UnityEngine;
using Zenject;

public class GlobalServicesInstaller : MonoInstaller
{
    [SerializeField] private GameObject _updateServicePrefab;
    public override void InstallBindings()
    {
        Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle().NonLazy();
        Container.Bind<IProgressService>().To<ProgressService>().AsSingle().NonLazy();
        Container.Bind<SceneLoader>().AsSingle().NonLazy();
        var updateService = Container.InstantiatePrefabForComponent<UpdateService>(_updateServicePrefab);
        Container.Bind(typeof(IUpdateService), typeof(ICoroutineRunner)).To<UpdateService>().FromInstance(updateService).AsSingle().NonLazy();
    }
}
