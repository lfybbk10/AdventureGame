
using System;

public interface ISaveLoadService
{
    void SaveProgress(PlayerProgress progress);
    PlayerProgress LoadProgress();
}
