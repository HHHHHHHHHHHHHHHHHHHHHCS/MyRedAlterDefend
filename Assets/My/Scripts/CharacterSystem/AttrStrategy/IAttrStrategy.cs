using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttrStrategy
{
    int GeAddMaxHPValue(int lv);//增加的最大血量
    int GetDmgDescValue(int lv);//抵御的伤害值
    int GetCritDmg(int lv,float critRate);//暴击增加的伤害
}
