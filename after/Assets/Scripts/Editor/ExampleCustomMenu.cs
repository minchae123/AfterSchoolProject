using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleCustomMenu : EditorWindow, IHasCustomMenu
{
    public void AddItemsToMenu(GenericMenu menu)
    {
        menu.AddItem(new GUIContent("방과후1"), true, () =>
        {
            Debug.Log("sdf");
        });

        menu.AddItem(new GUIContent("방과후 중급반"), false, () =>
        {
            Debug.Log("유니티 중급");
        });
    }

    [MenuItem("Window/커스텀 메뉴 윈도우")]
    static void open()
    {
        var window = GetWindow<ExampleCustomMenu>();
        var icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Scripts/icon.png");
        window.titleContent = new GUIContent("아이콘", icon);

    }

    [MenuItem("Window/zz/네스터드 윈도우")]
    static void NewNesstedOpationMenu()
    {
        Debug.Log("중첩");
    }

    [MenuItem("Window/zz/네스터드 윈도우2")]
    static void NewNesstedOpationMenu2()
    {
        Debug.Log("중첩2");
    }

    [MenuItem("alsco/new option %#q", false, 1)]
    static void NewHotKeyOptionMenu()
    {
        Debug.Log("단축1");
    }

    /*[MenuItem("alsco/new option &m", false, 3)]
    static void NewHotKeyOptionMenu2()
    {
        Debug.Log("단축2");
    }*/

    [MenuItem("alsco/new option HOME", false, 51)]
    static void NewHotKeyOptionMenu3()
    {
        Debug.Log("단축");
    }

    [MenuItem("alsco/new option F3", false, 53)]
    static void NewHotKeyOptionMenu4()
    {
        Debug.Log("단축4");
    }

    [MenuItem("Assets/Add Configuration^^")]
    static void AddConfig()
    {

    }

    [MenuItem("CONTEXT/Rigidbody/새 옵션")]
    static void AddContextRigidBodyMenu(MenuCommand menuCommand)
    {
        var rg = menuCommand.context as Rigidbody;
        Debug.Log("메뉴 :  " + rg.transform.name);
    }

    [MenuItem("CONTEXT/Transform/새 옵션")]
    static void AddContextTranformMenu()
    {
        Debug.Log("트랜스포옴??");
    }
}
