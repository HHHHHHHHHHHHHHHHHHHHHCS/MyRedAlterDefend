using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09Observer : MonoBehaviour
{
    private void Awake()
    {
        ConcreteSubject1 subject = new ConcreteSubject1();
        ConcreteObserver1 server1 = new ConcreteObserver1(subject);
        ConcreteObserver2 server2 = new ConcreteObserver2(subject);

        subject.SubjectState = "MonoBehaviour";
    }
}

public abstract class Subject
{
    private HashSet<Observer> observers; 

    public Subject()
    {
        observers = new HashSet<Observer>();
    }

    public void RegisterObserver(Observer ob)
    {
        observers.Add(ob);
    }

    public void RemoveObserver(Observer ob)
    {
        observers.Remove(ob);
    }

    public void NotifyObserver()
    {
        foreach(var ob in observers)
        {
            ob.OnUpdate();
        }
    }
}

public abstract class Observer
{
    protected Subject subject;

    public Observer(Subject _subject)
    {
        subject = _subject;
        subject.RegisterObserver(this);
    }

    public abstract void OnUpdate();
}

public class ConcreteSubject1 : Subject
{
    private string subjectState;

    public string SubjectState
    {
        get
        {
            return subjectState;
        }

        set
        {
            subjectState = value;
            NotifyObserver();
        }
    }

}

public class ConcreteObserver1 : Observer
{
    public ConcreteObserver1(Subject _subject) 
        : base(_subject)
    {
    }

    public override void OnUpdate()
    {
        Debug.Log("ConcreteObserver1:" + ((ConcreteSubject1)subject).SubjectState);
    }
}

public class ConcreteObserver2 : Observer
{
    public ConcreteObserver2(Subject _subject) 
        : base(_subject)
    {
    }

    public override void OnUpdate()
    {
        Debug.Log("ConcreteObserver2:" + ((ConcreteSubject1)subject).SubjectState);
    }
}