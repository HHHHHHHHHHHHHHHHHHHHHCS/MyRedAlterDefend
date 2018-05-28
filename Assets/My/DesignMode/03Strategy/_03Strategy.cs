using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _03Strategy : MonoBehaviour
{
    private void Start()
    {
        _StrategyContext sc = new _StrategyContext();
        sc.cal = new _StrategyA();
        sc.Cal();
        sc.cal = new _StrategyB();
        sc.Cal();
    }
}

public class _StrategyContext
{
    public _IStrategy cal;

    public void Cal()
    {
        cal.Cal();
    }
}

public interface _IStrategy
{
    void Cal();

}

public class _StrategyA : _IStrategy
{
    public void Cal()
    {
        Debug.Log("Use A Cal");
    }
}

public class _StrategyB : _IStrategy
{
    public void Cal()
    {
        Debug.Log("Use B Cal");
    }
}
