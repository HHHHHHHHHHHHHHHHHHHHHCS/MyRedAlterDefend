using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityTool 
{
    public static GameObject FindChild(GameObject parent,string childName)
    {
        var tsArray =  parent.GetComponentsInChildren<Transform>();
        foreach(Transform item in tsArray)
        {
            if(item.name==childName)
            {
                return item.gameObject;
            }
        }
        return null;
    }

    public static void AttachGameObject(GameObject parent,GameObject child)
    {
        Transform ts = child.transform;
        ts.SetParent(parent.transform);
        ts.localPosition = Vector3.zero;
        ts.localEulerAngles = Vector3.zero;
        ts.localScale = Vector3.one;
    }
}
