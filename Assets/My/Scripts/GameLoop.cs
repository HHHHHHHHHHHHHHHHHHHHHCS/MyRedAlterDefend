using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private static SceneController sceneController;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(sceneController==null)
        {
            sceneController = new SceneController();
            sceneController.SetState(SceneController.SceneState.BattleScene,true);
        }


    }


}
