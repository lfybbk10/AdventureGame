
using System;

public interface IProgressService : IService
{
    PlayerProgress Progress { get; set; }
    
    event Action<PlayerProgress> OnSaveProgress;
    
    event Action<PlayerProgress> OnLoadProgress;

    void SaveProgress();
    void LoadProgress();
    void InformProgressLoaders();
}
