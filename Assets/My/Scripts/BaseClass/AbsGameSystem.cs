using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsGameSystem 
{
    public virtual void OnInit() { }
    public virtual void OnUpdate() { }
    public virtual void OnRelease() { }
}
