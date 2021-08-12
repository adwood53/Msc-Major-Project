using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using FMODUnity;

public class intromanager : MonoBehaviour
{
    public StudioEventEmitter em;

    public Transform trackedPose;
    public Transform sceneObject;

    bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        trackedPose = GameObject.Find("TrackedPoseDriver").transform;
        StartCoroutine(LateStart(1.0f));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        em.Play();
        isPlaying = true;

        Vector3 pos = sceneObject.position + trackedPose.position;
        pos.y = Camera.main.transform.position.y - 0.45f;
        sceneObject.position = pos;

        yield return new WaitForSeconds(4f);
        SceneLoader.Instance.LoadNewScene("House_clean");
    }


    private void Update()
    {
        if (!em.IsPlaying() && isPlaying) SceneLoader.Instance.LoadNewScene("House_clean");
    }
}
