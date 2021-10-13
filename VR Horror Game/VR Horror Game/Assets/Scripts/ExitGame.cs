using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter[] ems;
    public string endScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var item in ems)
            {
                item.Stop();
            }
            SceneLoader.Instance.LoadNewScene(endScene);
        }
    }
}
