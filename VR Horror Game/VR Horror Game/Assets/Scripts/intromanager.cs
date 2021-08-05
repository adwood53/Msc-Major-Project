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

    // Start is called before the first frame update
    void Start()
    {
        em.Play();
        sceneObject.position = Camera.main.transform.position - offset.position;
    }

    private void Update()
    {
        if (!em.IsPlaying()) SceneManager.LoadScene("House_clean");
    }
}
