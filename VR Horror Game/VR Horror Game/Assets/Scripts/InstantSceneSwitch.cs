using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantSceneSwitch : MonoBehaviour
{
    public bool ready = false;

    public void Set(bool b)
    {
        ready = b;
    }
    public void Switch(string sceneName)
    {
        if(ready)
        {
            gameObject.GetComponent<DialInteractable>().colliders.Clear();
            StartCoroutine(change(sceneName));
        }
    }

    private IEnumerator change(string sceneName)
    {
        yield return new WaitForSeconds(0.05f);
        SceneLoader.Instance.LoadNewSceneInstant(sceneName);
    }
}
