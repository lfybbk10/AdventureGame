
using System;
using System.Collections;
using UnityEngine;

public class LoadingCurtain : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(0.02f);
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        canvasGroup.alpha = 1;
    }

    public void Hide()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        for (int i = 1; i <= 100; i++)
        {
            canvasGroup.alpha -= 0.01f;
            yield return _waitForSeconds;
        }
        gameObject.SetActive(false);
    }
}
