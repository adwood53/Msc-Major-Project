using UnityEditor;
using UnityEditor.SceneManagement;

public static class SceneMenu
{
    [MenuItem("Scenes/Intro")]
    public static void OpenIntro()
    {
        OpenScene("Intro");
    }
    [MenuItem("Scenes/House_clean")]
    public static void OpenHouseclean()
    {
        OpenScene("House_clean");
    }
    [MenuItem("Scenes/Maze")]
    public static void OpenMaze()
    {
        OpenScene("Maze");
    }


    private static void OpenScene(string sceneName)
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Persistent.unity", OpenSceneMode.Single);
        EditorSceneManager.OpenScene("Assets/Scenes/" + sceneName + ".unity", OpenSceneMode.Additive);
    }
}
