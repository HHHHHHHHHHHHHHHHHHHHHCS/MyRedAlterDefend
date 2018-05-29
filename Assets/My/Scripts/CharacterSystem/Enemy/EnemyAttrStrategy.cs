using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttrStrategy : IAttrStrategy
{
    public int GeAddMaxHPValue(int lv)
    {
        return (lv - 1) * 10;
    }

    public int GetDmgDescValue(int lv)
    {
        return (lv - 1) * 5;
    }

    public int GetCritDmg(int lv, float critRate)
    {
        float v = Random.Range(0, 1f);
        if (v <= critRate)
        {
            return (int)((lv - 1) * 10 * v);
        }
        return 0;
    }
}
