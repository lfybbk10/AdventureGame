
using Cinemachine;
using UnityEngine;
using Zenject;

public class HeroInstaller : MonoInstaller
{
    [SerializeField] private GameObject _heroPrefab;
    [SerializeField] private CinemachineVirtualCamera _heroCamera;
    [SerializeField] private Transform _spawnPoint;
    public override void InstallBindings()
    {
        var hero = Container.InstantiatePrefab(_heroPrefab, _spawnPoint.position, Quaternion.identity, null);
        _heroCamera.Follow = hero.transform;
        _heroCamera.LookAt = hero.transform;
    }
}
