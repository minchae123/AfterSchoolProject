using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameController : MonoBehaviour
{
    public string name1;

    [ContextMenu("Reset Menu")]
    private void ResetName()
    {
        name1 = string.Empty;
    }
}
