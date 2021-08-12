using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildLoader : MonoBehaviour
{
    [Tooltip("The first scene to load when the application is loaded outside of the editor. This ensures the Persistent scene loads first.")]
    public string startScene = "Intro"; //The first scene to load when the application is loaded outside of the editor. This ensures the Persistent scene loads first.

    // Start is called before the first frame update
    void Awake()
    {
        if (!Application.isEditor)
            SceneManager.LoadSceneAsync(startScene, LoadSceneMode.Additive);
    }



}
