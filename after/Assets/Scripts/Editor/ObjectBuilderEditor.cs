using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectBuilderScripts))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ObjectBuilderScripts obs = (ObjectBuilderScripts)target;

        if(GUILayout.Button("Object Builder Btn"))
        {
            obs.BuildObject();
        }
    }
}
