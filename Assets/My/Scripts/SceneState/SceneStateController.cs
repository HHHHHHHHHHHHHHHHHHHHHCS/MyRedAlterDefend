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

    private AbsSceneState nowState;
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

    public void SetState(SceneState state,bool unLoad=false)
    {
        if (nowState != null)
        {
            nowState.StateEnd();
        }
        AbsSceneState newState;
        absSceneStateList.TryGetValue(state, out newState);
        nowState = newState;
        if (unLoad)
        {
            asyncOperation = null;
            nowState.StateStart();
        }
        else if (nowState != null)
        {
            asyncOperation = SceneManager.LoadSceneAsync(nowState.SceneName);
        }
    }

    public void StateUpdate()
    {
        if (asyncOperation != null)
        {
            if (asyncOperation.isDone)
            {
                if (nowState != null)
                {
                    nowState.StateStart();
                }
                asyncOperation = null;
            }
            else
            {
                return;
            }
        }

        if (nowState != null)
        {
            nowState.StateUpdate();
        }
    }
}
