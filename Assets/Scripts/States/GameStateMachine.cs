
using System;
using System.Collections.Generic;
using Zenject;

public class GameStateMachine
{
    private readonly Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    [Inject]
    public GameStateMachine(LoadingCurtain loadingCurtain, SceneLoader sceneLoader, ISaveLoadService saveLoadService, IProgressService progressService)
    {
        _states = new Dictionary<Type, IExitableState>()
        {
            [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
            [typeof(LoadProgressState)] = new LoadProgressState(this, saveLoadService, progressService),
            [typeof(LoadLevelState)] = new LoadLevelState(loadingCurtain,sceneLoader,this, progressService),
            [typeof(GameLoopState)] = new GameLoopState()
        };
        
        Enter<BootstrapState>();
    }

    public void Enter<TState>() where TState : class, IState
    {
        IState state = ChangeState<TState>();
        state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
    {
        TState state = ChangeState<TState>();
        state.Enter(payload);
    }

    private TState ChangeState<TState>() where TState : class,IExitableState
    {
        _activeState?.Exit();
        TState state = GetState<TState>();
        _activeState = state;
        return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState => 
        _states[typeof(TState)] as TState;
}
