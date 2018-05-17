using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsSceneState
{
    public string SceneName { get; private set; }
    public SceneController.SceneState SceneState { get; private set; }

    public AbsSceneState(SceneController ctrl
        , SceneController.SceneState _sceneState, string _sceneName)
    {
        ctrl.AddState(_sceneState, this);
        SceneState = _sceneState;
        SceneName = _sceneName;
    }

    /// <summary>
    /// 进入的时候调用
    /// </summary>
    public virtual void StateStart() { }

    /// <summary>
    /// 结束的时候调用
    /// </summary>
    public virtual void StateEnd() { }

    /// <summary>
    /// 每桢调用
    /// </summary>
    public virtual void StateUpdate() { }
}
