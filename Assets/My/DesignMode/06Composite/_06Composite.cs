using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _06Composite : MonoBehaviour
{

}

public abstract class DMCompent
{
    public string Name { get; protected set; }
    protected List<DMCompent> childList;

    public DMCompent(string _name)
    {
        childList = new List<DMCompent>();
        Name = _name;
    }

    public abstract void AddChild(DMCompent _compent);
    public abstract void RemoveChild(DMCompent _compent);
    public abstract DMCompent GetChild(int _index);
}

public class DMLeaf : DMCompent
{
    public DMLeaf(string _name) : base(_name)
    {
    }

    public override void AddChild(DMCompent _compent)
    {
        return;
    }

    public override DMCompent GetChild(int _index)
    {
        return null;
    }

    public override void RemoveChild(DMCompent _compent)
    {
        return;
    }
}

public class DMCompsite : DMCompent
{
    public DMCompsite(string _name) : base(_name)
    {
    }

    public override void AddChild(DMCompent _compent)
    {
        childList.Add(_compent);
    }

    public override DMCompent GetChild(int _index)
    {
        return childList[_index];
    }

    public override void RemoveChild(DMCompent _compent)
    {
        childList.Remove(_compent);
    }
}

