
using UnityEngine;

public class LoadLevelState : IPayloadState<string>
{
    private readonly LoadingCurtain _loadingCurtain;
    private readonly SceneLoader _sceneLoader;
    private readonly GameStateMachine _stateMachine;
    private readonly IProgressService _progressService;

    public LoadLevelState(LoadingCurtain loadingCurtain, SceneLoader sceneLoader, GameStateMachine stateMachine, IProgressService progressService)
    {
        _loadingCurtain = loadingCurtain;
        _sceneLoader = sceneLoader;
        _stateMachine = stateMachine;
        _progressService = progressService;
    }
    public void Enter(string name)
    {
        _loadingCurtain.Show();
        _sceneLoader.Load(name, onLoaded);
    }

    private void onLoaded()
    {
        _progressService.InformProgressLoaders();
        _stateMachine.Enter<GameLoopState>();
    }

    public void Exit()
    {
        _loadingCurtain.Hide();
    }
}
