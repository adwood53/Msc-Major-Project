using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipToMaze : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Skip());
    }

    IEnumerator Skip()
    {
        yield return new WaitForSeconds(4.0f);
        SceneLoader.Instance.LoadNewSceneInstant("Maze");
    }
}
