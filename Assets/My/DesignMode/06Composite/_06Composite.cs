using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _06Composite : MonoBehaviour
{
    private void Awake()
    {
        DMCompsite root = new DMCompsite("Root");

        DMLeaf leaf1 = new DMLeaf("GameObject");
        DMLeaf leaf2 = new DMLeaf("GameObject (2)");
        DMCompsite gameObject1 = new DMCompsite("GameObject (1)");

        root.AddChild(leaf1);
        root.AddChild(gameObject1);
        root.AddChild(leaf2);

        DMLeaf child1 = new DMLeaf("GameObject");
        DMLeaf child2 = new DMLeaf("GameObject (1)");
        gameObject1.AddChild(child1);
        gameObject1.AddChild(child2);

        ReadComponent(root);
    }

    private void ReadComponent(DMCompent component)
    {
        Debug.Log(component.Name);

        var childList = component.ChildList;
        if(childList==null|| childList.Count==0)
        {
            return;
        }
        foreach(var item in childList)
        {
            ReadComponent(item);
        }
    }
}

public abstract class DMCompent
{
    public string Name { get; protected set; }
    public List<DMCompent> ChildList { get; protected set; }

    public DMCompent(string _name)
    {
        ChildList = new List<DMCompent>();
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
        ChildList.Add(_compent);
    }

    public override DMCompent GetChild(int _index)
    {
        return ChildList[_index];
    }

    public override void RemoveChild(DMCompent _compent)
    {
        ChildList.Remove(_compent);
    }
}

