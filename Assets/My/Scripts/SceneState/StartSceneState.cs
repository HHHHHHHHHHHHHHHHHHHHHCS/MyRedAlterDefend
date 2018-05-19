using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneState : AbsSceneState
{
    private Image logo;
    private float startTime, startSceneTime, changeTime;

    public StartSceneState(SceneController ctrl) : base(ctrl, SceneController.SceneState.StartScene
        , "01_StartScene")
    {

    }

    protected override void StateAwakeThing()
    {
        startTime = 0; startSceneTime = 2.5f; changeTime = 4;
        logo = GameObject.Find("UIRoot/LogoImg").GetComponent<Image>();
        logo.color = Color.black;
        startTime = Time.realtimeSinceStartup;
    }

    protected override void StateStartThing()
    {
        SceneController.SetState(SceneController.SceneState.MainMenuScene, false, false);
    }

    protected override void StateUpdateThing()
    {
        var timer = Time.realtimeSinceStartup - startTime;
        if (timer >= startSceneTime)
        {
            SceneController.StartLoadedScene();
        }
        else
        {
            logo.color = Color.Lerp(Color.black, Color.white
                , (timer) / changeTime);
        }
    }
}
