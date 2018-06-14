using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _05Builder : MonoBehaviour
{
    private void Awake()
    {
        IBuilder fatBuilder = new FatPersonBuilder();
        IBuilder thinBuilder = new ThinPersonBuilder();

        Person fat = Director.Construct(fatBuilder);
        fat.ShowAll();
    }
}

class Person
{
    public List<string> parts = new List<string>();

    public void AddPart(string _part)
    {
        parts.Add(_part);
    }


    public void ShowAll()
    {
        foreach(var item in parts)
        {
            Debug.Log(item);
        }
    }
}

class FatPerson : Person
{

}


class ThinPerson : Person
{

}

interface IBuilder
{
    void AddHead();
    void AddBody();
    void AddHand();
    void AddFeet();

    Person GerResult();
}

class FatPersonBuilder : IBuilder
{
    private Person person;

    public FatPersonBuilder()
    {
        person = new Person();
    }

    public void AddBody()
    {
        person.AddPart("Fat Body");
    }

    public void AddFeet()
    {
        person.AddPart("Fat Feet");
    }

    public void AddHand()
    {
        person.AddPart("Fat Hand");
    }

    public void AddHead()
    {
        person.AddPart("Fat Head");
    }

    public Person GerResult()
    {
        return person;
    }
}




class ThinPersonBuilder : IBuilder
{
    private Person person;

    public ThinPersonBuilder()
    {
        person = new Person();
    }

    public void AddBody()
    {
        person.AddPart("Thin Body");
    }

    public void AddFeet()
    {
        person.AddPart("Thin Feet");
    }

    public void AddHand()
    {
        person.AddPart("Thin Hand");
    }

    public void AddHead()
    {
        person.AddPart("Thin Head");
    }

    public Person GerResult()
    {
        return person;
    }
}

static class Director
{
    public static Person Construct(IBuilder builder)
    {
        builder.AddHead();
        builder.AddBody();
        builder.AddHand();
        builder.AddFeet();
        return builder.GerResult();
    }
}
