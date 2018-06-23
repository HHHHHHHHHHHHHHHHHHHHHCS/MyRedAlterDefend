using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneState : AbsSceneState
{
    private GameFacade gameFacade;

    public BattleSceneState(SceneController ctrl) : base(ctrl, SceneController.SceneState.BattleScene
        , "03_BattleScene")
    {

    }

    protected override void StateAwakeThing()
    {
        gameFacade = GameFacade.Instance.OnInit();
    }

    protected override void StateEndThing()
    {
        gameFacade.OnRelease();
    }

    protected override void StateUpdateThing()
    {
        if(gameFacade.IsGameOver)
        {//但是正常不应该这样 因为还要存在 结束展示的菜单
            //SceneController.SetState(SceneController.SceneState.MainMenuScene, false, true);
        }
        else
        {
            gameFacade.OnUpdate();
        }
    }
}
