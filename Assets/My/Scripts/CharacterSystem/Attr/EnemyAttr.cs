using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttr : CharacterAttr
{
    public EnemyAttr(IAttrStrategy _attrStrategy, string _chararcterName, string _headSprite, string _prefabName, int _maxHP, float _moveSpeed, int _lv = 0, float _critRate = 0) : base(_attrStrategy, _chararcterName, _headSprite, _prefabName, _maxHP, _moveSpeed, _lv, _critRate)
    {
    }
}
