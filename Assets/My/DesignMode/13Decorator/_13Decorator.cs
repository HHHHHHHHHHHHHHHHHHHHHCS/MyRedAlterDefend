using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _13Decorator : MonoBehaviour
{
    private void Awake()
    {
        Coffee coffee = new Espresso();
        coffee = coffee.AddDecorator(new MoCha());
        coffee = coffee.AddDecorator(new Milk());
        coffee = coffee.AddDecorator(new MoCha());
        coffee = coffee.AddDecorator(new Milk());
        Debug.Log(coffee.Cost());
    }
}

public abstract class Coffee
{
    public abstract double Cost();
    public abstract double Capacity();
    public virtual Coffee AddDecorator(Decorator decorator)
    {
        decorator.coffee = this;
        return decorator;
    }
}

public class Espresso : Coffee
{
    public override double Cost()
    {
        return 2.5d;
    }

    public override double Capacity()
    {
        return 10;
    }
}


public class Decaf : Coffee
{
    public override double Cost()
    {
        return 2d;
    }

    public override double Capacity()
    {
        return 10;
    }
}

public class Decorator:Coffee
{
    public Coffee coffee { get; set; }
    //public Decorator (Coffee  _coffee)
    //{
    //    coffee = _coffee;
    //}
    public override double Cost()
    {
        return coffee.Cost();
    }

    public override double Capacity()
    {
        return 10;
    }
}

public class MoCha : Decorator
{
    public override double Cost()
    {
        return coffee.Cost() + 0.1d;
    }
}

public class Milk : Decorator
{

    public override double Cost()
    {
        return coffee.Cost() + 0.5d;
    }
}

