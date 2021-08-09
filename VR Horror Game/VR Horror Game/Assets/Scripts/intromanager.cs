using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class intromanager : MonoBehaviour
{
    public StudioEventEmitter em;

    public Transform sceneObject;
    public Transform offset;

    bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart(1.0f));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        em.Play();
        isPlaying = true;
        sceneObject.position = Camera.main.transform.position - offset.position;
    }


    private void Update()
    {
        if (!em.IsPlaying() && isPlaying) SceneLoader.Instance.LoadNewScene("House_clean");
    }
}
