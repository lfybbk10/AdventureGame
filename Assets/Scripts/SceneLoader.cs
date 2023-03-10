
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader
{
    private readonly ICoroutineRunner _coroutineRunner;

    [Inject]
    public SceneLoader(ICoroutineRunner coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
    }
    
    public void Load(string name, Action onLoaded = null)
    {
        _coroutineRunner.StartCoroutine(LoadScene(name,onLoaded));
    }

    private IEnumerator LoadScene(string name, Action onLoaded = null)
    {
        if (SceneManager.GetActiveScene().name == name)
        {
            yield break;
        }
      
        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

        while (!waitNextScene.isDone)
            yield return null;
      
        onLoaded?.Invoke();
    }
}
