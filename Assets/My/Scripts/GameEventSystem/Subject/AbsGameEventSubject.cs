using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsGameEventSubject
{
    private HashSet<AbsGameEventObserver> observers;

    public AbsGameEventSubject()
    {
        observers = new HashSet<AbsGameEventObserver>();
    }

    public void RegisterObserver(AbsGameEventObserver server)
    {
        observers.Add(server);
        server.Subject=this;
    }

    public void RemoveObserver(AbsGameEventObserver server)
    {
        server.Subject = null;
        observers.Remove(server);
    }

    public virtual void TriggerEvent()
    {
        NotifyObserver();
    }

    public void NotifyObserver()
    {
        foreach (var item in observers)
        {
            item.OnReceiveNotify();
        }
    }
}
