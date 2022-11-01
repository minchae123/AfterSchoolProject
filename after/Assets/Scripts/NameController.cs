using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameController : MonoBehaviour
{
    public string name1;

    [ContextMenuItem("리셋네임2", "")]
    public string name2;

    [ContextMenu("Reset Menu")]
    private void ResetName()
    {
        name1 = string.Empty;
    }

    private void Resetname2()
    {
        name2 = "민채";
    }
}
