using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10Memento : MonoBehaviour
{
    private void Start()
    {
        /*
        Originator originator = new Originator();
        originator.SetState("Test1");
        originator.ShowState();

        Memento memento1 = originator.CreateMemento();

        originator.SetState("Test2");
        originator.ShowState();

        originator.SetMemento(memento1);
        */
        CareTaker careTaker = new CareTaker();

        Originator originator = new Originator();
        originator.SetState("Test1");
        originator.ShowState();
        careTaker.AddMemento("V1.0", originator.CreateMemento());

        originator.SetState("Test2");
        originator.ShowState();
        careTaker.AddMemento("V2.0", originator.CreateMemento());

        originator.SetState("Test3");
        originator.ShowState();
        careTaker.AddMemento("V3.0", originator.CreateMemento());

        originator.SetMemento(careTaker.GetMemento("V2.0"));
        originator.ShowState();

    }
}

class Originator
{
    private string state;
    public void SetState(string _state)
    {
        state = _state;
    }

    public void ShowState()
    {
        Debug.Log("Originator State:" + state);
    }

    public Memento CreateMemento()
    {
        Memento memento = new Memento();
        memento.SetState(state);
        return memento;
    }

    public void SetMemento(Memento memento)
    {
         SetState(memento.GetState());
    }
}

class Memento
{
    private string state;

    public void SetState(string _state)
    {
        state = _state;
    }

    public string GetState()
    {
        return state;
    }

}

class CareTaker
{
    Dictionary<string, Memento> mementoDic = new Dictionary<string, Memento>();

    public void AddMemento(string key , Memento memento)
    {
        mementoDic.Add(key, memento);
    }

    public Memento GetMemento(string version)
    {
        Memento memento = null;
        mementoDic.TryGetValue(version, out memento);
        return memento;
    }
}

