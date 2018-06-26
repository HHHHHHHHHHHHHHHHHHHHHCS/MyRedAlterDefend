using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _07Command : MonoBehaviour
{

	// Use this for initialization
	void Start () {
        DMInvokerManager manager = new DMInvokerManager();
        manager.Add(new DMInvoker01());
        manager.Add(new DMInvoker02());
        manager.Add(new DMInvoker03());

        manager.Execute("Test");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class DMInvokerManager
{
    public List<AbsDMInvoker> list = new List<AbsDMInvoker>();

    public void Add(AbsDMInvoker dmi)
    {
        list.Add(dmi);
    }

    public void Remove(AbsDMInvoker dmi)
    {
        list.Remove(dmi);
    }

    public void Clear()
    {
        list.Clear();
    }

    public void Execute(string str)
    {
        foreach(var item in list)
        {
            item.Execute(str);
        }
    }
}

public abstract class AbsDMInvoker
{
    //public event Cmd_Dg Cmd_Evt;
    //public delegate void Cmd_Dg(string str);

    public abstract void Execute(string str);
}

public class DMInvoker01: AbsDMInvoker
{
    public override void Execute(string str)
    {
        Debug.Log("DMInvoker01:" + str);
    }
}

public class DMInvoker02 : AbsDMInvoker
{
    public override void Execute(string str)
    {
        Debug.Log("DMInvoker02:" + str);
    }
}

public class DMInvoker03 : AbsDMInvoker
{
    public override void Execute(string str)
    {
        Debug.Log("DMInvoker03:" + str);
    }
}