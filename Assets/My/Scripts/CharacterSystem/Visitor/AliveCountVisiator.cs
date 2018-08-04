using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveCountVisiator :ICharacterVisiator
{
    public int EnemyCount { get; private set; }
    public int SoliderCount { get; private set; }

    public void OnInit()
    {
        EnemyCount = 0;
        SoliderCount = 0;
    }

    public void VisitorEnemy(AbsEnemy enemy)
    {
        if(!enemy.IsKilled)
        {
            EnemyCount++;
        }
    }

    public void VisitorSoldier(AbsSoldier solider)
    {
        if (!solider.IsKilled)
        {
            SoliderCount++;
        }
    }
}
