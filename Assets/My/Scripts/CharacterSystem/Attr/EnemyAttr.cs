using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttr : CharacterAttr
{
    public EnemyAttr(IAttrStrategy _attrStrategy, CharacterBaseAttr _baseAttr, int _lv , float _critRate)
        : base(_attrStrategy, _baseAttr,  _lv, _critRate)
    {
        
    }
}
