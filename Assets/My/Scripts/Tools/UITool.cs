using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UITool
{
    private static GameObject uiRoot;

    public static GameObject FindUIRoot(string name = "UIRoot")
    {
        if (uiRoot == null)
        {
            uiRoot = GameObject.Find(name);
        }
        return uiRoot;
    }

    public static Transform FindUIPanel(string path)
    {
        return FindUIRoot().transform.Find(path);
    }

    public static T FindUI<T>(ref T refObject, Transform parent, string path) where T : Object
    {
        return refObject = parent.Find(path).GetComponent<T>();
    }
}
