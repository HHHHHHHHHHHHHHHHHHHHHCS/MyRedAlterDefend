using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField]
    private SceneController.SceneState state;

    private static SceneController sceneController;

    private void Awake()
    {
        if (sceneController == null)
        {
            DontDestroyOnLoad(gameObject);
            sceneController = new SceneController();
            sceneController.SetState(state, true);
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
