using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootstrap : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private LoadingCurtain _loadingCurtain;
    private Game _game;

    private void Awake()
    {
        _game = new Game(_loadingCurtain,this);
        _game.StateMachine.Enter<BootstrapState>();
        
        DontDestroyOnLoad(this);
    }
}
