using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneState : AbsSceneState
{
    public StartSceneState(SceneController ctrl) : base(ctrl, SceneController.SceneState.StartScene
        , "01_StartScene")
    {

    }
}
