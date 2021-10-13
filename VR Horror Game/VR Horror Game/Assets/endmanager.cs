using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using FMODUnity;

public class endmanager : MonoBehaviour
{
    public GameObject end1;
    public GameObject end2;

    public int FearRequirement = 3;
    bool fullEnding = false;

    Transform trackedPose;
    public Transform sceneObject;

    public string nextScene = "Intro";

    bool isPlaying = false;
    public bool skipCredits = false;

    // Start is called before the first frame update
    void Start()
    {
        if (GameData.Instance.FearLevel >= FearRequirement)
        {
            end1.SetActive(false);
            end2.SetActive(true);
        }
        else
        {
            end1.SetActive(true);
            end2.SetActive(false);
        }
        trackedPose = GameObject.Find("TrackedPoseDriver").transform;
        StartCoroutine(LateStart(1.0f));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        Vector3 pos = sceneObject.position + trackedPose.position;
        pos.y = Camera.main.transform.position.y - 0.45f;
        sceneObject.position = pos;

        if (skipCredits)
        {
            yield return new WaitForSeconds(4.0f);
            SceneLoader.Instance.LoadNewScene(nextScene);
        }
    }

}
