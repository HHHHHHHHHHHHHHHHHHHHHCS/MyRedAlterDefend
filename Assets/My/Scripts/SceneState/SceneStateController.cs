using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    public enum SceneState
    {
        StartScene,
        MainMenuScene,
        BattleScene
    }
    private Dictionary<SceneState, AbsSceneState> absSceneStateList;

    private AbsSceneState nowState, newState;
    private AsyncOperation asyncOperation;

    public SceneController()
    {
        absSceneStateList = new Dictionary<SceneState, AbsSceneState>();
        new StartSceneState(this);
        new MainMenuState(this);
        new BattleSceneState(this);
    }

    public void AddState(SceneState _stateEnum, AbsSceneState _absState)
    {
        absSceneStateList.Add(_stateEnum, _absState);
    }

    /// <summary>
    /// 设置场景
    /// </summary>
    /// <param name="state">场景</param>
    /// <param name="unLoad">需要执行加载事件</param>
    public void SetState(SceneState _state, bool unLoad = false, bool waitAysnc = true)
    {
        absSceneStateList.TryGetValue(_state, out newState);

        if (unLoad)
        {
            ChanegSceneEvent();
        }
        else if (newState != null)
        {
            asyncOperation = SceneManager.LoadSceneAsync(newState.SceneName);
            asyncOperation.allowSceneActivation = waitAysnc;
        }
    }

    public void StateUpdate()
    {
        if (asyncOperation != null
            && asyncOperation.isDone && newState != null)
        {
            ChanegSceneEvent();
        }

        if (nowState != null)
        {
            nowState.StateUpdate();
        }
    }

    public void StartLoadedScene()
    {
        if (asyncOperation != null)
        {
            asyncOperation.allowSceneActivation = true;
            ChanegSceneEvent();
        }
    }

    private void ChanegSceneEvent()
    {
        asyncOperation = null;
        if (nowState != null)
        {
            nowState.StateEnd();
        }
        newState.StateAwake();
        nowState = newState;
        newState = null;
    }
}
