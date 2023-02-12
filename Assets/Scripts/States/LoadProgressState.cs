
public class LoadProgressState : IState
{
    private GameStateMachine _stateMachine;
    private ISaveLoadService _saveLoadService;
    private IProgressService _progressService;
    
    public LoadProgressState(GameStateMachine stateMachine, ISaveLoadService saveLoadService, IProgressService progressService)
    {
        _stateMachine = stateMachine;
        _saveLoadService = saveLoadService;
        _progressService = progressService;
    }
    public void Enter()
    {
        _progressService.LoadProgress();
        _stateMachine.Enter<LoadLevelState,string>(_progressService.Progress.WorldData.LevelName);
    }
    public void Exit()
    {
        
    }
}
