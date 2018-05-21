using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade
{
    private static GameFacade _instance;

    public static GameFacade Instance
    {
        get
        {
            if(_instance==null)
            {
                _instance = new GameFacade();
            }
            return _instance;
        }
    }
    
    /// <summary>
    /// 内部单例化保护
    /// </summary>
    private GameFacade()
    {

    }

    public bool IsGameOver { get; set; }

    public GameFacade OnInit()
    {
        return this;
    }

    public void OnRelease()
    {
        
    }

    public void OnUpdate()
    {

    }
}
