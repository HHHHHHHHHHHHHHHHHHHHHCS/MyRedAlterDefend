using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class E_GameEventSystem 
{
    public static void RegisterObserver(this GameFacade facade
        ,GameEventType _type, params AbsGameEventObserver[] _server)
    {
        facade.GameEventSystem.RegisterObserver(_type,_server);
    }

    public static void RemoveObserver(this GameFacade facade 
        ,GameEventType _type, params AbsGameEventObserver[] _server)
    {
        facade.GameEventSystem.RemoveObserver(_type, _server);
    }

    public static void TriggerEvent(this GameFacade facade 
        ,GameEventType _type)
    {
        facade.GameEventSystem.TriggerEvent(_type);
    }
}
