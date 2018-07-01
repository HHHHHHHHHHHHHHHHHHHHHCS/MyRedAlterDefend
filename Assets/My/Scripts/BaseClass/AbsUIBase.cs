using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsUIBase
{
    public Transform PanelRoot { get; protected set; }

    public virtual void OnInit() { }

    public virtual void OnUpdate() { }

    public virtual void OnRelease() { }

    public void FindUI<T>(ref T refObject, string path) where T : Object
    {
        UITool.FindUI(ref refObject, PanelRoot, path);
    }

    public virtual void OnShow()
    {
        if (!PanelRoot.gameObject.activeInHierarchy)
            PanelRoot.gameObject.SetActive(true);
    }

    public virtual void OnHide()
    {
        if (PanelRoot.gameObject.activeInHierarchy)
            PanelRoot.gameObject.SetActive(false);
    }
}
