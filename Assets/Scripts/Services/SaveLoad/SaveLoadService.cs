using System;
using UnityEngine;
using Zenject;

public class SaveLoadService : ISaveLoadService
{
    private const string ProgressKey = "Progress";

    public void SaveProgress(PlayerProgress progress)
    {
        PlayerPrefs.SetString(ProgressKey, progress.ToJson());
    }

    public PlayerProgress LoadProgress()
    {
        return PlayerPrefs.GetString(ProgressKey)?
            .ToDeserialized<PlayerProgress>();
    }
}
