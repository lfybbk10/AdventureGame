
using UnityEngine;

public class BootstrapState : IState
{
    private const string Initial = "Initial";
    private const string Main = "Main";
    private GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
    }
    public void Enter()
    {
        RegisterServices();
        _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        EnterLoadLevel();
    }

    private void RegisterServices()
    {
        
    }

    private void EnterLoadLevel()
    {
        _stateMachine.Enter<LoadLevelState,string>(Main);
    }

    
    
    public void Exit()
    {
        
    }
}
