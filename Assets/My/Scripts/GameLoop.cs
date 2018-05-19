using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private static SceneController sceneController;

    private void Awake()
    {
        if (sceneController == null)
        {
            DontDestroyOnLoad(gameObject);
            sceneController = new SceneController();
            sceneController.SetState(SceneController.SceneState.StartScene,true);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        sceneController.StateUpdate();
    }
}
