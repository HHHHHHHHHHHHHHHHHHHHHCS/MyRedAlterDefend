using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSystem : AbsGameSystem
{
    private Dictionary<SoldierType, SoldierCamp> soldierCamps;

    public override void OnInit()
    {
        base.OnInit();
        soldierCamps = new Dictionary<SoldierType, SoldierCamp>();
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Rookie);
    }

    private void InitCamp(SoldierType soldierType)
    {
        GameObject gameObject = null;
        string gameObjectName = null;
        string name = null;
        string icon = null;
        Vector3 position = Vector3.zero;
        float trainTime = 0;

        switch (soldierType)
        {
            case SoldierType.Rookie:
                gameObjectName = "SoldierCamp_Rookie";
                name = "新手兵营";
                icon = "RookieCamp";
                trainTime = 3;
                break;
            case SoldierType.Sergeant:
                gameObjectName = "SoldierCamp_Sergeant";
                name = "中士兵营";
                icon = "SergeantCamp";
                trainTime = 4;
                break;
            case SoldierType.Captain:
                gameObjectName = "SoldierCamp_Captain";
                name = "上尉兵营";
                icon = "CaptainCamp";
                trainTime = 5;
                break;
            default:
                break;
        }
        gameObjectName = "Camp/" + gameObjectName;
        gameObject = GameObject.Find(gameObjectName);
        position = UnityTool.FindChild(gameObject, "TrainPoint").transform.position;
        SoldierCamp camp = new SoldierCamp(gameObject, name, icon, soldierType, position, trainTime);
        soldierCamps.Add(soldierType, camp);
    }

    public override void OnUpdate()
    {
        foreach(var item in soldierCamps.Values)
        {
            item.OnUpdate();
        }
    }
}
