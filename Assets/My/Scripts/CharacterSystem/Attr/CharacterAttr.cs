using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttr
{
    public string ChararcterName { get { return BaseAttr.ChararcterName; } }
    public string HeadSprite { get { return BaseAttr.HeadSprite; } }
    public string PrefabName { get { return BaseAttr.PrefabName; } }
    public int MaxHP { get { return BaseAttr.MaxHP; } }
    public float MoveSpeed { get { return BaseAttr.MoveSpeed; } }

    public int Lv { get; protected set; }
    public float CritRate { get; protected set; }//暴击率0-1  敌人才有的
    public int CritValue { get { return AttrStrategy.GetCritDmg(Lv, CritRate); } }

    public IAttrStrategy AttrStrategy { get; protected set; }
    public CharacterBaseAttr BaseAttr { get; protected set; }

    public int NowHp { get; set; }
    public int DmgDescValue { get; protected set; }

    public CharacterAttr(IAttrStrategy _attrStrategy, CharacterBaseAttr _baseAttr, int _lv =1 ,float _critRate=0)
    {
        AttrStrategy = _attrStrategy;
        BaseAttr = _baseAttr;
        Lv = _lv;
        CritRate = _critRate;
        DmgDescValue = AttrStrategy.GetDmgDescValue(Lv);
    }


}
