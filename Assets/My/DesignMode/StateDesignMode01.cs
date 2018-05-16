using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDesignMode01 : MonoBehaviour
{
    private void Awake()
    {
        Context context = new Context();
        context.SetState(new ConcreteA(context));

        context.Handle(5);

        context.Handle(15);

        context.Handle(7);
    }

}

public interface IState
{
    void Handle(int arg);
}

public class Context
{
    private IState state;
    public void SetState(IState _state)
    {
        state = _state;
    }

    public void Handle(int arg)
    {
        state.Handle(arg);
    }
}



public class ConcreteA : IState
{
    private Context context;

    public ConcreteA(Context _context)
    {
        context = _context;
    }

    public void Handle(int arg)
    {
        Debug.Log("ConcreteStateA.Handle:" + arg);
        if(arg>10)
        {
            context.SetState(new ConcreteB(context));
        }
    }
}

public class ConcreteB : IState
{
    private Context context;

    public ConcreteB(Context _context)
    {
        context = _context;
    }

    public void Handle(int arg)
    {
        Debug.Log("ConcreteStateB.Handle:" + arg);
        if (arg <= 10)
        {
            context.SetState(new ConcreteA(context));
        }
    }
}
