using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12Adapter : MonoBehaviour
{
    private void Awake()
    {
        Adapter adapter1 = new Adapter(new NewPlugin());
        IStandardInterface standard1 = adapter1;
        standard1.Request();
    }
}

interface IStandardInterface
{
    void Request();
}

class StandardImplementA : IStandardInterface
{
    public void Request()
    {
        Debug.Log("使用标准的请求!");
    }
}

class Adapter : IStandardInterface
{
    private NewPlugin newPlugin;

    public Adapter(NewPlugin _newPlugin)
    {
        newPlugin = _newPlugin;
    }

    public void Request()
    {
        newPlugin.SpecificRequest();
        Debug.Log($"{newPlugin.test}");
    }
}

class NewPlugin
{
    public string test = "23333";

    public void SpecificRequest()
    {
        Debug.Log("使用特殊的请求!");
    }

}



