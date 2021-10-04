using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantSceneSwitch : MonoBehaviour
{
    public void Switch(string sceneName)
    {
        SceneLoader.Instance.LoadNewSceneInstant(sceneName);
    }
}
