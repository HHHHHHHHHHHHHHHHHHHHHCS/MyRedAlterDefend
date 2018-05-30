using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DesignMode
{
    public class _02Bridge : MonoBehaviour
    {
        private void Start()
        {
            IRenderEngine renderEngine = new _SuperRender();

            _02Sphere sphere = new _02Sphere(renderEngine);
            sphere.Draw();
            _02Cube cube = new _02Cube(renderEngine);
            cube.Draw();
            _02Capsule capsule = new _02Capsule(renderEngine);
            capsule.Draw();
        }
    }

    public abstract class Abs_Shape
    {
        public string name;
        public IRenderEngine renderEngine;

        public Abs_Shape(IRenderEngine _renderEngine)
        {
            renderEngine = _renderEngine;
        }

        public void Draw()
        {
            renderEngine.Render(name);
        }
    }


    public interface IRenderEngine
    {
        void Render(string name);
    }

    public class _02Capsule : Abs_Shape
    {
        public _02Capsule(IRenderEngine _renderEngine) : base(_renderEngine)
        {
            name = "Capsule";
        }
    }

    public class _02Cube : Abs_Shape
    {
        public _02Cube(IRenderEngine _renderEngine) : base(_renderEngine)
        {
            name = "Cube";
        }
    }

    public class _02Sphere : Abs_Shape
    {
        public _02Sphere(IRenderEngine _renderEngine) : base(_renderEngine)
        {
            name = "Sphere";
        }
    }

    public class _OpenGL : IRenderEngine
    {
        public void Render(string name)
        {
            Debug.Log("OpenGL绘制" + name);
        }
    }

    public class _DirectX : IRenderEngine
    {
        public void Render(string name)
        {
            Debug.Log("DirectX绘制" + name);
        }
    }

    public class _SuperRender : IRenderEngine
    {
        public void Render(string name)
        {
            Debug.Log("SuperRender绘制" + name);
        }
    }

    /*
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

    public class _DirectX
    {
        public void Render(string name)
        {
            Debug.Log("_DirectX绘制" + name);
        }
    }
    */
}