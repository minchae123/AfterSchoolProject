using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow
{
    Color color;

    PopupWindow popupWindow;

    [MenuItem("Window/Coloizer")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Colorize");
    }

    private void OnGUI()
    {
        GUILayout.Label("Color Object", EditorStyles.boldLabel);
        color = EditorGUILayout.ColorField("Color", color);

        ExamplePopup examplePopup = new ExamplePopup();

        if (GUILayout.Button("brn"))
        {
            Colorize();
        }

        if (GUILayout.Button("ÆË¾÷ ¶ç¿ì±â", GUILayout.Width(200)))
        {
            var acticeRect = GUILayoutUtility.GetLastRect();
            PopupWindow.Show(acticeRect, examplePopup);
        }
    }

    void Colorize()
    {
        foreach(GameObject obi in Selection.gameObjects)
        {
            Renderer red = obi.GetComponent<Renderer>();
            
            if(red != null)
            {
                red.material.color = color;
            }
        }
    }

    public class ExamplePopup : PopupWindowContent
    {
        public override void OnGUI(Rect rect)
        {
            EditorGUILayout.LabelField("ÆË¾÷");
        }
        public override void OnOpen()
        {
            Debug.Log("ÆË¾÷¿­¸²");
        }
        public override void OnClose()
        {
            Debug.Log("ÆË¾÷´ÝÈû");
        }

        public override Vector2 GetWindowSize()
        {
            return new Vector2(500, 500);
        }
    }
}
