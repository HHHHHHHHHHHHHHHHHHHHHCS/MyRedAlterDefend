using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : AbsSceneState
{
    public MainMenuState(SceneController ctrl) : base(ctrl, SceneController.SceneState.MainMenuScene
        , "02_MainMenuScene")
    {

    }

    protected override void StateStartThing()
    {
        GameObject.Find("UIRoot/StartButton").GetComponent<Button>()
            .onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        SceneController.SetState(SceneController.SceneState.BattleScene, false, true);
    }
}
