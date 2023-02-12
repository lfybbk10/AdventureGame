using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameBootstrap : MonoInstaller
{
    [SerializeField] private GameObject _loadingCurtainPrefab;

    public override void InstallBindings()
    {
        Container.Bind<GameStateMachine>().AsSingle().NonLazy();
        var loadingCurtain = Container.InstantiatePrefabForComponent<LoadingCurtain>(_loadingCurtainPrefab);
        Container.Bind<LoadingCurtain>().FromInstance(loadingCurtain).AsSingle().NonLazy();
    }
}
