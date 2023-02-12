
using System;

public class ProgressService : IProgressService
{
    public event Action<PlayerProgress> OnSaveProgress;
    
    public event Action<PlayerProgress> OnLoadProgress;
    public PlayerProgress Progress { get; set; }
    
    private readonly ISaveLoadService _saveLoadService;

    public ProgressService(ISaveLoadService saveLoadService)
    {
        _saveLoadService = saveLoadService;
    }

    public void SaveProgress()
    {
        OnSaveProgress?.Invoke(Progress);
        _saveLoadService.SaveProgress(Progress);
    }

    public void LoadProgress()
    {
        Progress = _saveLoadService.LoadProgress() ?? NewProgress();
    }

    public void InformProgressLoaders()
    {
        OnLoadProgress?.Invoke(Progress);
    }
    
    private PlayerProgress NewProgress() => new PlayerProgress("Main");
}
