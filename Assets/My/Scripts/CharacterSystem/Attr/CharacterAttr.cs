using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttr
{
    public string ChararcterName { get { return baseAttr.ChararcterName; } }
    public string HeadSprite { get { return baseAttr.HeadSprite; } }
    public string PrefabName { get { return baseAttr.PrefabName; } }
    public int MaxHP { get { return baseAttr.MaxHP; } }
    public float MoveSpeed { get { return baseAttr.MoveSpeed; } }

    public int Lv { get; protected set; }
    public float CritRate { get; protected set; }//暴击率0-1  敌人才有的
    public int CritValue { get { return attrStrategy.GetCritDmg(Lv, CritRate); } }

    protected IAttrStrategy attrStrategy;
    protected CharacterBaseAttr baseAttr;

    public int NowHp { get; set; }
    public int DmgDescValue { get; protected set; }

    public CharacterAttr(IAttrStrategy _attrStrategy, CharacterBaseAttr _baseAttr, int _lv =1 ,float _critRate=0)
    {
        attrStrategy = _attrStrategy;
        baseAttr = _baseAttr;
        Lv = _lv;
        CritRate = _critRate;
        DmgDescValue = attrStrategy.GetDmgDescValue(Lv);
    }


}
