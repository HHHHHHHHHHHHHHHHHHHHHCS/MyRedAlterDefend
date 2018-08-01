using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ArchievementMemento
{
    private int enemyKilledCount;
    private int soldierKilledCount;
    private int maxStageLv;

    public int EnemyKilledCount
    {
        get
        {
            return enemyKilledCount;
        }

        set
        {
            enemyKilledCount = value;
        }
    }
    public int SoldierKilledCount
    {
        get
        {
            return soldierKilledCount;
        }

        set
        {
            soldierKilledCount = value;
        }
    }
    public int MaxStageLv
    {
        get
        {
            return maxStageLv;
        }

        set
        {
            maxStageLv = value;
        }
    }

    public void SaveData()
    {
        Dictionary<PlayerAttribute, int> newDic = new Dictionary<PlayerAttribute, int>();
        newDic.Add(PlayerAttribute.EnemyKilledCount, EnemyKilledCount);
        newDic.Add(PlayerAttribute.SoldierKilledCount, SoldierKilledCount);
        newDic.Add(PlayerAttribute.MaxStage, MaxStageLv);
        JsonManager.Instance.UpdateData(newDic);
    }

    public void LoadData()
    {
        var cacheDic = JsonManager.Instance.ReadData();
        EnemyKilledCount = cacheDic[PlayerAttribute.EnemyKilledCount];
        SoldierKilledCount = cacheDic[PlayerAttribute.SoldierKilledCount];
        MaxStageLv = cacheDic[PlayerAttribute.MaxStage];
    }
}
