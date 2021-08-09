using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{

    public UnityEvent OnLoadBegin = new UnityEvent();
    public UnityEvent OnLoadEnd = new UnityEvent();
    
    public ScreenFader screenFader = null;
    private bool isLoading = false;

    [Tooltip("Adds an additional delay to the loading coroutines to test on fast loading scenes.")] public bool debugTime = false;

    private void Awake()
    {
        SceneManager.sceneLoaded += SetActiveScene; // Attaches the set active scene function to the SceneManager.sceneLoaded action
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SetActiveScene; // Detatches the set active scene function
    }

    public void LoadNewScene(string sceneName)
    {
        if (!isLoading)
            StartCoroutine(LoadScene(sceneName));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        isLoading = true; // Loading start

        // Unloads current scene, fades screen and triggers OnLoadBegin event
        OnLoadBegin?.Invoke();
        yield return screenFader.StartFadeIn();
        yield return StartCoroutine(UnloadCurrent());

        if (debugTime) // Adds debug delay
            yield return new WaitForSeconds(3.0f);

        // Loads new scene, unfades screen and triggers OnLoadEnd event
        yield return StartCoroutine(LoadNew(sceneName));
        yield return screenFader.StartFadeOut();
        OnLoadEnd?.Invoke();

        isLoading = false; // Loading end

        yield return null;
    }

    private IEnumerator UnloadCurrent()
    {
        AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        while (!unloadOperation.isDone)
            yield return null;
    }

    private IEnumerator LoadNew(string sceneName)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!loadOperation.isDone)
            yield return null;
    }

    private void SetActiveScene(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
    }
}
