using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttr : CharacterAttr
{
    public SoldierAttr(IAttrStrategy _attrStrategy, CharacterBaseAttr _baseAttr,int _lv)
        : base(_attrStrategy, _baseAttr, _lv)
    {
    }
}
