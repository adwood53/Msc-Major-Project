using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using FMODUnity;

public class intromanager : MonoBehaviour
{
    public StudioEventEmitter timedStudioEventEmitter;
    public StudioEventEmitter[] studioEventEmitters;

    Transform trackedPose;
    public Transform sceneObject;

    public string nextScene = "House_clean";

    bool isPlaying = false;
    public bool skipIntro = false;

    // Start is called before the first frame update
    void Start()
    {
        trackedPose = GameObject.Find("TrackedPoseDriver").transform;
        StartCoroutine(LateStart(1.0f));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        timedStudioEventEmitter.Play();
        foreach (StudioEventEmitter em in studioEventEmitters)
        {
            em.Play();
        }
        isPlaying = true;

        Vector3 pos = sceneObject.position + trackedPose.position;
        pos.y = Camera.main.transform.position.y - 0.45f;
        sceneObject.position = pos;

        if(skipIntro)
        {
            yield return new WaitForSeconds(4.0f);
            SceneLoader.Instance.LoadNewScene(nextScene);
        }
    }


    private void Update()
    {
        if (!timedStudioEventEmitter.IsPlaying() && isPlaying) SceneLoader.Instance.LoadNewScene(nextScene);
    }
}
