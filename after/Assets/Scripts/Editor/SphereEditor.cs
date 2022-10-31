using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SphereController))]
public class SphereEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SphereController sphereController = (SphereController)target;
        sphereController.baseSize = EditorGUILayout.Slider("Size!" ,sphereController.baseSize, 0.3f, 3f);

        sphereController.transform.localScale = Vector3.one * sphereController.baseSize;
    }
}
