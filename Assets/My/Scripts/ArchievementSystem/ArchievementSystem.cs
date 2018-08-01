using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchievementSystem : AbsGameSystem
{
    private int enemyKilledCount = 0;
    private int soldierKilledCount = 0;
    private int maxStageLv = 0;

    public override void OnInit()
    {
        base.OnInit();
        GameFacade.Instance.RegisterObserver(GameEventType.EnemyKilled
            , new EnemyKilledObserverArchievement(this));
        GameFacade.Instance.RegisterObserver(GameEventType.SoldierKilled
    , new SoldierKilledObserverArchievement(this));
        GameFacade.Instance.RegisterObserver(GameEventType.NewStage
    , new NewStageOvserverArchievement(this));
    }

    public void AddEnemyKilledCount(int number=1)
    {
        enemyKilledCount += number;
        Debug.Log("AddEnemyKilledCount :" + enemyKilledCount);
    }

    public void AddSoldierKilledCount(int number = 1)
    {
        soldierKilledCount += number;
        Debug.Log("AddSoldierKilledCount :" + soldierKilledCount);
    }

    public void SetMaxStageLv(int lv = 1)
    {
        if(lv>maxStageLv)
        {
            maxStageLv = lv;
            Debug.Log("SetMaxStageLv :" + lv);
        }

    }

    public ArchievementMemento CreateMemento()
    {
        ArchievementMemento archievementMemento = new ArchievementMemento();
        archievementMemento.EnemyKilledCount = enemyKilledCount;
        archievementMemento.SoldierKilledCount = soldierKilledCount;
        archievementMemento.MaxStageLv = maxStageLv;
        return archievementMemento;
    }

    public void SetMemento(ArchievementMemento memento)
    {
        enemyKilledCount = memento.EnemyKilledCount;
        soldierKilledCount = memento.SoldierKilledCount;
        maxStageLv = memento.MaxStageLv;
    }
}
