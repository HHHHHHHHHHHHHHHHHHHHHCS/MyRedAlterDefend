using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _08ChainOfResponsibility : MonoBehaviour
{
    private void Awake()
    {
        char problem = 'a';

        DMHandlerA handlerA = new DMHandlerA();
        DMHandlerB handlerB = new DMHandlerB();
        DMHandlerC handlerC = new DMHandlerC();
        handlerA.SetNextHandler(handlerB).SetNextHandler(handlerC);

        handlerA.DoHandle(problem);
    }
}

public abstract class IDMHandler
{
    public char ConditionChar { get; set; }
    public IDMHandler NextHandler { get; set; }
    public abstract void Handle(char ch);

    public IDMHandler SetNextHandler(IDMHandler handler)
    {
        NextHandler = handler;
        return handler;
    }

    public void DoHandle(char ch)
    {
        if (ch == ConditionChar)
        {
            Handle(ch);
        }
        else if(NextHandler!=null)
        {
            NextHandler.Handle(ch);
        }
    }
}

class DMHandlerA: IDMHandler
{
    public DMHandlerA()
    {
        ConditionChar = 'a';
    }

    public override void Handle(char ch)
    {
            Debug.Log("处理完成A问题");
    }
}

class DMHandlerB: IDMHandler
{
    public DMHandlerB()
    {
        ConditionChar = 'b';
    }

    public override void Handle(char ch)
    {
        Debug.Log("处理完成B问题");
    }
}

class DMHandlerC : IDMHandler
{
    public DMHandlerC()
    {
        ConditionChar = 'c';
    }

    public override void Handle(char ch)
    {
        Debug.Log("处理完成C问题");
    }
}