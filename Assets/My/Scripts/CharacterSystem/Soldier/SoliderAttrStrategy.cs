using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderAttrStrategy : IAttrStrategy
{
    public int GeAddMaxHPValue(int lv)
    {
        return (lv-1)*10;
    }

    public int GetDmgDescValue(int lv)
    {
        return (lv - 1) * 5;
    }

    public int GetCritDmg(int lv, float critRate)
    {
        return 0;
    }

}
