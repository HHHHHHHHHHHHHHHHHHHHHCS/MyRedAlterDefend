﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameEventType
{
    Null,
    EnemyKilled,
    SoldierKilled,
    NewStage,
}


public class GameEventSystem : AbsGameSystem
{
    private Dictionary<GameEventType, AbsGameEventSubject> gameEvents;

    public override void OnInit()
    {
        gameEvents = new Dictionary<GameEventType, AbsGameEventSubject>();
    }

    private void InitGameEvents()
    {

    }

    public void RegisterObserver(GameEventType _type,params AbsGameEventObserver[] _server)
    {
        var subject = GetGameEvents(_type);

        foreach (var item in _server)
        {
            subject.RegisterObserver(item);
        }
    }

    public void RemoveObserver(GameEventType _type, params AbsGameEventObserver[] _server)
    {
        var subject = GetGameEvents(_type);

        foreach (var item in _server)
        {
            subject.RemoveObserver(item);
        }
    }

    public void TriggerEvent(GameEventType _type)
    {
        GetGameEvents(_type).TriggerEvent();
    }


        
    private AbsGameEventSubject GetGameEvents(GameEventType _type)
    {
        AbsGameEventSubject subject = null;
        if (!gameEvents.TryGetValue(_type,out subject))
        {
            switch (_type)
            {
                case GameEventType.Null:
                    break;
                case GameEventType.EnemyKilled:
                    subject = new EnemyKilledSubject();
                    gameEvents.Add(GameEventType.EnemyKilled, subject);
                    break;
                case GameEventType.SoldierKilled:
                    subject = new SoldierKilledSubject();
                        gameEvents.Add(GameEventType.SoldierKilled, subject);
                    break;
                case GameEventType.NewStage:
                    subject = new NewStageSubject();
                    gameEvents.Add(GameEventType.NewStage, subject);
                    break;
            }
        }
        if (subject == null)
        {
            Debug.Log("gameEvents not have key:" + gameEvents);
        }
        return subject;
    }
}
