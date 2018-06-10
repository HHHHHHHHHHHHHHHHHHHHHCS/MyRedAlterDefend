using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFactory : ICharacterFactory
{
    public AbsCharacter CreateCharacter<T>(WeaponType _weaponType, Vector3 _pos, int _lv = 1) where T : AbsCharacter, new()
    {
        AbsCharacter character = new T();




        return null;
    }


    public CharacterAttr SetCharacterAttr<T>(int _lv)
    {
        CharacterAttr attr = null;

        string name = null, headSprite = null, prefabName = null;
        int maxHP = 0,lv = _lv;
        float moveSpeed = 0;


        Type t = typeof(T);
        if (t == typeof(SoldierCaptain))
        {
            name = "上尉士兵";
            maxHP = 100;
            moveSpeed = 3.5f;
            headSprite = "CaptainIcon";
            prefabName = "Soldier1";
        }
        else if (t == typeof(SoldierSergeant))
        {
            name = "中士士兵";
            maxHP = 90;
            moveSpeed = 3;
            headSprite = "SergeantIcon";
            prefabName = "Soldier3";
        }
        else if (t == typeof(SoldierRookie))
        {
            name = "新手士兵";
            maxHP = 80;
            moveSpeed = 2.5f;
            headSprite = "RookieIcon";
            prefabName = "Soldier2";
        }
        else
        {
            Debug.Log("CharacterAttr 类型" + t + "不属于ISoldier，无法创建");
            return attr;
        }

        attr = new SoldierAttr(new SoliderAttrStrategy(), name, headSprite, prefabName
            , maxHP, moveSpeed, lv);
        return attr;
    }
}
