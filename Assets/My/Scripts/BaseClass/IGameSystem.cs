using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameSystem 
{
    void OnInit();
    void OnUpdate();
    void OnRelease();
}
