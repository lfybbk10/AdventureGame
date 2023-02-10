
using Cinemachine;
using UnityEngine;
using Zenject;

public class HeroInstaller : MonoInstaller
{
    [SerializeField] private GameObject _heroPrefab;
    [SerializeField] private CinemachineVirtualCamera _heroCamera;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private HeroMove _heroMove;
    public override void InstallBindings()
    {
        var hero = Container.InstantiatePrefab(_heroPrefab, _spawnPoint.position, Quaternion.identity, null);
        _heroCamera.Follow = hero.transform;
        _heroCamera.LookAt = hero.transform;
        
        //Container.Bind<HeroMove>().FromInstance(_heroMove).AsSingle().NonLazy();
    }
}
