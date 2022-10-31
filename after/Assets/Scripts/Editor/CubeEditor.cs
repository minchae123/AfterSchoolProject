using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CubeController))]
public class CubeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        CubeController cubeController = (CubeController)target;
        GUILayout.BeginHorizontal();

        if(GUILayout.Button("Genreate Color"))
        {
            cubeController.GenerateColor();
        }

        if (GUILayout.Button("Reset"))
        {
            cubeController.ResetColor();
        }

        GUILayout.EndHorizontal();
    }
}
