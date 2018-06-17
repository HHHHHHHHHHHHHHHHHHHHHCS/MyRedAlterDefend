using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseAttr
{
    public string ChararcterName { get; protected set; }
    public string HeadSprite { get; protected set; }
    public string PrefabName { get; protected set; }

    public int Lv { get; protected set; }
    public int MaxHP { get; protected set; }
    public float MoveSpeed { get; protected set; }
    public float CritRate { get; protected set; }//暴击率0-1  敌人才有的

    public CharacterBaseAttr( string _chararcterName, string _headSprite, string _prefabName
        , int _maxHP, float _moveSpeed, int _lv = 1, float _critRate = 0)
    {
        ChararcterName = _chararcterName;
        HeadSprite = _headSprite;
        PrefabName = _prefabName;
        Lv = _lv;
        MaxHP = _maxHP;
        MoveSpeed = _moveSpeed;
        CritRate = _critRate;
    }
}
