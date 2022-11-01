using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomWindow : EditorWindow
{
    [MenuItem("Window/커스텀윈도우")]
    static void open()
    {
        GetWindow<CustomWindow>();
    }

    private void OnGUI()
    {
        EditorGUILayout.ObjectField(null, typeof(Object), true);
        EditorGUILayout.ObjectField(null, typeof(Material), true);
        EditorGUILayout.ObjectField(null, typeof(AudioClip), false);

        var options = new[] { GUILayout.Width(64), GUILayout.Height(64) };

        EditorGUILayout.ObjectField(null, typeof(Texture), true, options);
        EditorGUILayout.ObjectField(null, typeof(Sprite), true, options);

        EditorGUILayout.LabelField("Parent");
        EditorGUI.indentLevel++;
        EditorGUILayout.LabelField("Child1");
        EditorGUILayout.LabelField("Child2");
        EditorGUILayout.LabelField("Child3");
        EditorGUI.indentLevel--;
        EditorGUILayout.LabelField("Parent2");
        EditorGUI.indentLevel++;
        EditorGUILayout.LabelField("Child4");
        EditorGUILayout.LabelField("Child5");
        EditorGUI.indentLevel++;
        EditorGUILayout.LabelField("Child6");


    }
}
