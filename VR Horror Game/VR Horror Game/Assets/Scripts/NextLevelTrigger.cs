using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter em;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameData.Instance.LevelUp();
            em.Play();
            SceneLoader.Instance.LoadNewScene("House_clean");
        }
    }
}
