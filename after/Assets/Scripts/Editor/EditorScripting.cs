using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorScripting : EditorWindow
{
    string testString = "First TextField";
    [MenuItem("Window/TestMenuItem")]
    public static void ShowWindow()
    {
        //GetWindow<Ŀ����������Ÿ��>("ExampleWindow");
        EditorWindow.GetWindow(typeof(EditorScripting));
    }
    private void OnGUI()
    {
        GUILayout.Label("First Lable", EditorStyles.boldLabel);
        testString = EditorGUILayout.TextField("TF_Name", testString);
        
        if(GUILayout.Button("press btn"))
        {
            Debug.Log("123");
        }
    }
}
