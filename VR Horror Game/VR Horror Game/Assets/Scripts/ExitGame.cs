using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public int fearLevelRequirement;

    public string endScene;

    private void OnTriggerEnter(Collider other)
    {
        SceneLoader.instance.LoadNewScene(endScene);
    }
}
