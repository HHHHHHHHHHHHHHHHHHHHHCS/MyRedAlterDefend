using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _02Bridge : MonoBehaviour
{
    private void Start()
    {
        _02Sphere sphere = new _02Sphere();
        sphere.Draw();
        _02Cube cube = new _02Cube();
        cube.Draw();
        _02Capsule capsule = new _02Capsule();
        capsule.Draw();
    }
}

public class _02Capsule
{
    public string name = "Capsule";

    public _OpenGL openGL = new _OpenGL();

    public void Draw()
    {
        openGL.Render(name);
    }
}

public class _02Cube
{
    public string name = "Cube";

    public _OpenGL openGL = new _OpenGL();

    public void Draw()
    {
        openGL.Render(name);
    }
}

public class _02Sphere
{
    public string name = "Sphere";

    public _OpenGL openGL = new _OpenGL();

    public void Draw()
    {
        openGL.Render(name);
    }
}

public class _OpenGL
{
    public void Render(string name)
    {
        Debug.Log("OpenGL绘制"+name);
    }
}