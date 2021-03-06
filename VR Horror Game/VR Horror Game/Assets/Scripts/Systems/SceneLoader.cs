using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneLoader : Singleton<SceneLoader>
{
    public GameObject xrinteractionManagerObject;
    private XRInteractionManager xrinteractionManager;
    public XRBaseInteractor[] interactors;
    public UnityEvent OnLoadBegin = new UnityEvent();
    public UnityEvent OnLoadEnd = new UnityEvent();

    public ScreenFader screenFader = null;
    private bool isLoading = false;

    [Tooltip("Adds an additional delay to the loading coroutines to test on fast loading scenes.")] 
    public bool debugTime = false;

    private void Awake()
    {
        SceneManager.sceneLoaded += SetActiveScene; // Attaches the set active scene function to the SceneManager.sceneLoaded action
        xrinteractionManager = xrinteractionManagerObject.GetComponent<XRInteractionManager>();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SetActiveScene; // Detatches the set active scene function
    }

    public void LoadNewScene(string sceneName)
    {
        if (!isLoading)
            StartCoroutine(LoadScene(sceneName, false));
    }

    public void LoadNewSceneInstant(string sceneName)
    {
        if (!isLoading)
            StartCoroutine(LoadScene(sceneName, true));
    }

    private IEnumerator LoadScene(string sceneName, bool instant)
    {
        isLoading = true; // Loading start

        // Unloads current scene, fades screen and triggers OnLoadBegin event
        OnLoadBegin?.Invoke();

        if (instant)
        {
            float duration = screenFader.FadeInInstant();
            yield return new WaitForSeconds(3f);
        }
        else
        {
            float duration = screenFader.FadeIn();
            yield return new WaitForSeconds(duration+2f);
        }
        yield return new WaitForEndOfFrame();
        yield return StartCoroutine(UnloadCurrent());

        if (debugTime) // Adds debug delay
            yield return new WaitForSeconds(8.0f);

        //xrinteractionManager = xrinteractionManagerObject.AddComponent<XRInteractionManager>() as XRInteractionManager;
        //foreach (var item in interactors)
        //{
        //    item.interactionManager = xrinteractionManager;
        //}

        // Loads new scene, unfades screen and triggers OnLoadEnd event
        yield return StartCoroutine(LoadNew(sceneName));
        OnLoadEnd?.Invoke();

        isLoading = false; // Loading end

        yield return null;
    }

    private IEnumerator UnloadCurrent()
    {
        //Destroy(xrinteractionManager);
        AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        while (!unloadOperation.isDone)
        {
            yield return null;
        }
    }

    private IEnumerator LoadNew(string sceneName)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        loadOperation.allowSceneActivation = false;

        while (!loadOperation.isDone)
        {
            // Output the current progress
            //loadingText.text = "Loading progress: " + (loadOperation.progress * 100) + "%";

            // Check if the load has finished
            if (loadOperation.progress >= 0.9f)
            {
                loadOperation.allowSceneActivation = true;
                yield return null;
            }
        }
    }

    private void SetActiveScene(Scene scene, LoadSceneMode mode)
    {
        IEnumerator coroutine = SetActiveSceneCoroutine(scene, mode);
        StartCoroutine(coroutine);
    }

    private IEnumerator SetActiveSceneCoroutine(Scene scene, LoadSceneMode mode)
    {
        yield return new WaitForEndOfFrame();
        SceneManager.SetActiveScene(scene);
        screenFader.FadeOut();;
    }
}
