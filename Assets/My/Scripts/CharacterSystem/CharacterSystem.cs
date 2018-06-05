using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystem : AbsGameSystem
{
    private List<AbsCharacter> soldierList;
    private List<AbsCharacter> enemyList;


    public override void OnInit()
    {
        soldierList = new List<AbsCharacter>();
        enemyList = new List<AbsCharacter>();

    }

    public override void OnUpdate()
    {
        OnUpdateSoldier();
        OnUpdateEnemy();
    }

    private void OnUpdateSoldier()
    {
        foreach (var item in soldierList)
        {
            item.OnUpdate();
            item.OnUpdateFSMAI(enemyList);
        }
    }

    private void OnUpdateEnemy()
    {
        foreach (var item in enemyList)
        {
            item.OnUpdate();
            item.OnUpdateFSMAI(soldierList);
        }
    }

    public void AddEnemy(AbsEnemy _enemy)
    {
        enemyList.Add(_enemy);
    }

    public void RemoveEnemy(AbsEnemy _enemy)
    {
        enemyList.Remove(_enemy);
    }

    public void AddSoldier(AbsSoldier _soldier)
    {
        soldierList.Add(_soldier);
    }

    public void RemoveAddSoldier(AbsSoldier _soldier)
    {
        soldierList.Remove(_soldier);
    }
}
