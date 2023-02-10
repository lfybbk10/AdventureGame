
using UnityEngine;

public class LoadLevelState : IPayloadState<string>
{
    private readonly LoadingCurtain _loadingCurtain;
    private readonly SceneLoader _sceneLoader;
    private readonly GameStateMachine _stateMachine;

    public LoadLevelState(LoadingCurtain loadingCurtain, SceneLoader sceneLoader, GameStateMachine stateMachine)
    {
        _loadingCurtain = loadingCurtain;
        _sceneLoader = sceneLoader;
        _stateMachine = stateMachine;
    }
    public void Enter(string name)
    {
        Debug.Log("load");
        _loadingCurtain.Show();
        _sceneLoader.Load(name, onLoaded);
    }

    private void onLoaded()
    {
        _stateMachine.Enter<GameLoopState>();
    }
    
    public void Exit()
    {
        _loadingCurtain.Hide();
    }
}
