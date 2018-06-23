using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsSceneState
{
    public string SceneName { get; private set; }
    public SceneController SceneController { get; private set; }
    public SceneController.SceneState SceneState { get; private set; }

    protected bool isFirst;

    public AbsSceneState(SceneController _ctrl
        , SceneController.SceneState _sceneState, string _sceneName)
    {
        _ctrl.AddState(_sceneState, this);
        SceneController = _ctrl;
        SceneState = _sceneState;
        SceneName = _sceneName;
    }

    /// <summary>
    /// 初始化的时候调用
    /// </summary>
    public void StateAwake()
    {
        isFirst = true;
        StateAwakeThing();
    }
    protected virtual void StateAwakeThing()
    {
    }


    /// <summary>
    /// 进入的时候调用
    /// </summary>
    public void StateStart()
    {
        isFirst = false;
        StateStartThing();
    }
    protected virtual void StateStartThing()
    {
    }


    /// <summary>
    /// 结束的时候调用
    /// </summary>
    public void StateEnd()
    {
        StateEndThing();
    }
    protected virtual void StateEndThing()
    {
    }


    /// <summary>
    /// 每帧调用
    /// </summary>
    public void StateUpdate()
    {
        if (isFirst)
        {
            StateStart();
        }
        StateUpdateThing();
    }

    protected virtual void StateUpdateThing()
    {
    }
}
