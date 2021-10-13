using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PictureFade))]
public class PictureFadeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PictureFade myScript = (PictureFade)target;
        if (GUILayout.Button("Fade In"))
        {
            myScript.Fade(true);
        }
        if (GUILayout.Button("Fade Out"))
        {
            myScript.Fade(false);
        }
    }
}
