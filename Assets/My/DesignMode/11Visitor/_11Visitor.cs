using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11Visitor : MonoBehaviour
{
    private void Awake()
    {
        ShapeContainer container = new ShapeContainer();

        Sphere sphere1 = new Sphere();
        Cylinder cylinder1 = new Cylinder();
        Cylinder cylinder2 = new Cylinder();
        Cube cube1 = new Cube();
        Cube cube2 = new Cube();
        Cube cube3 = new Cube();


        container.AddShape(sphere1);
        container.AddShape(cylinder1);
        container.AddShape(cylinder2);
        container.AddShape(cube1);
        container.AddShape(cube2);
        container.AddShape(cube3);

        AmountVisitor amountVisitor = new AmountVisitor();
        container.RunVisitor(amountVisitor);
        Debug.Log(amountVisitor.amount);

        CubeAmountVisitor cubeAmountVisitor = new CubeAmountVisitor();
        container.RunVisitor(cubeAmountVisitor);
        Debug.Log(cubeAmountVisitor.amount);

        EdgeAmountVisitor edgeAmountVisitor = new EdgeAmountVisitor();
        container.RunVisitor(edgeAmountVisitor);
        Debug.Log(edgeAmountVisitor.amount);
    }
}

class ShapeContainer
{
    public HashSet<AbsShape> shapeSet = new HashSet<AbsShape>();

    public void AddShape(AbsShape shape)
    {
        shapeSet.Add(shape);
    }


    public void RunVisitor(IVisitor visitor)
    {
        foreach(var item in shapeSet)
        {
            item.RunVisitor(visitor);
        }
    }
}

abstract class AbsShape
{
    public abstract void RunVisitor(IVisitor visitor);
}

class Sphere : AbsShape
{
    public override void RunVisitor(IVisitor visitor)
    {
        visitor.VisitorSphere(this);
    }
}

class Cylinder : AbsShape
{
    public override void RunVisitor(IVisitor visitor)
    {
        visitor.VisitorCylinder(this);
    }
}

class Cube : AbsShape
{
    public override void RunVisitor(IVisitor visitor)
    {
        visitor.VisitorCube(this);
    }
}

interface IVisitor
{
    void VisitorSphere(Sphere sphere);
    void VisitorCylinder(Cylinder cylinder);
    void VisitorCube(Cube cube);
}

class AmountVisitor : IVisitor
{
    public int amount = 0;

    public void VisitorCube(Cube cube)
    {
        amount++;
    }

    public void VisitorCylinder(Cylinder cylinder)
    {
        amount++;
    }

    public void VisitorSphere(Sphere sphere)
    {
        amount++;
    }
}

class CubeAmountVisitor : IVisitor
{
    public int amount = 0;

    public void VisitorCube(Cube cube)
    {
        amount++;
    }

    public void VisitorCylinder(Cylinder cylinder)
    {

    }

    public void VisitorSphere(Sphere sphere)
    {

    }
}

class EdgeAmountVisitor : IVisitor
{
    public int amount;

    public void VisitorCube(Cube cube)
    {
        amount += 30;
    }

    public void VisitorCylinder(Cylinder cylinder)
    {
        amount += 20;
    }

    public void VisitorSphere(Sphere sphere)
    {
        amount += 12;
    }
}
