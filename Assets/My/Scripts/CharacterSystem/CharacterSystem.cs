using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystem : AbsGameSystem
{
    private List<AbsCharacter> soldierList;
    private List<AbsCharacter> enemyList;

    private HashSet<AbsCharacter> destoryCharacterSet;

    public override void OnInit()
    {
        soldierList = new List<AbsCharacter>();
        enemyList = new List<AbsCharacter>();
        destoryCharacterSet = new HashSet<AbsCharacter>();
    }

    public override void OnUpdate()
    {
        OnUpdateSoldier();
        OnUpdateEnemy();

        RemoveDeadList(soldierList);
        RemoveDeadList(enemyList);
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
        GameFacade.Instance.UpdateAliveCount();
    }

    public void RemoveEnemy(AbsEnemy _enemy)
    {
        enemyList.Remove(_enemy);
        GameFacade.Instance.UpdateAliveCount();
    }

    public void AddSoldier(AbsSoldier _soldier)
    {
        soldierList.Add(_soldier);
        GameFacade.Instance.UpdateAliveCount();
    }

    public void RemoveAddSoldier(AbsSoldier _soldier)
    {
        soldierList.Remove(_soldier);
        GameFacade.Instance.UpdateAliveCount();
    }

    public void RemoveDeadList(List<AbsCharacter> list)
    {
        for(int i=list.Count-1;i>=0;i--)
        {
            var item = list[i];
            if(item.IsKilled)
            {
                destoryCharacterSet.Add(item);
                list.Remove(item);
            }
        }


        foreach(var item in destoryCharacterSet)
        {
            item.OnUpdate();
            if (item.CanDesotry)
            {
                item.OnRelease();
            }
        }
        destoryCharacterSet.RemoveWhere(x => x.CanDesotry);
    }

    public void RunVisitor(ICharacterVisiator characterVisiator)
    {
        characterVisiator.OnInit();
        foreach (var item in soldierList)
        {
            item.RunVisitor(characterVisiator);
        }
        foreach (var item in enemyList)
        {
            item.RunVisitor(characterVisiator);
        }
    }
}
