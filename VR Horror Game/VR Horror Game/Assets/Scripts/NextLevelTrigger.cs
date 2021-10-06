using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameData.Instance.LevelUp();
            SceneLoader.Instance.LoadNewScene("House_clean");
        }
    }
}
