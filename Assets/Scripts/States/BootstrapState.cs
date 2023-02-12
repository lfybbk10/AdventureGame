

using Zenject;

public class BootstrapState : IState
{
    private const string Initial = "Initial";
    private const string Main = "Main";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
    }
    public void Enter()
    {
        _stateMachine.Enter<LoadProgressState>();
    }

    private void EnterLoadLevel()
    {
        
    }

    public void Exit()
    {
        
    }
}
