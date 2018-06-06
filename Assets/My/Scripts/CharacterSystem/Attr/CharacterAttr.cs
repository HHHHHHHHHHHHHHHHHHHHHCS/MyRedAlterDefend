using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttr
{
    public string ChararcterName { get; protected set; }
    public string HeadSprite { get; protected set; }
    public int MaxHP { get; protected set; }
    public float MoveSpeed { get; protected set; }
    public int Lv { get; protected set; }
    public int CritRate { get; protected set; }//暴击率0-1  敌人才有的

    protected IAttrStrategy attrStrategy;

    public int NowHp { get; set; }
    public int DmgDescValue { get; protected set; }

    public CharacterAttr(IAttrStrategy _attrStrategy)
    {
        attrStrategy = _attrStrategy;
        DmgDescValue = attrStrategy.GetDmgDescValue(Lv);
    }

    public int CritValue
    {
        get
        {
            return attrStrategy.GetCritDmg(Lv, CritRate);
        }
    }

}
