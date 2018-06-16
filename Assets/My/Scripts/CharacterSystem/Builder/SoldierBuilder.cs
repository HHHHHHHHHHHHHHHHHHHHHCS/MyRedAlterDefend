using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBuilder : AbsCharacterBuilder
{
    public SoldierBuilder(AbsCharacter _character, Type _t, WeaponType _weaponType
        , Vector3 _spawnPosition, int _lv)
        : base(_character, _t, _weaponType, _spawnPosition, _lv)
    {

    }

    public override CharacterAttr AddCharacterAttr()
    {
        CharacterAttr attr = null;

        string name = null, headSprite = null;
        int maxHP = 0;
        float moveSpeed = 0;

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

    public override GameObject AddGameObject()
    {
        var _gameObject = FactoryManager.AssetFactory.LoadSoldier(prefabName);
        return _gameObject;
    }

    public override AbsWeapon AddWeapon()
    {
        var weapon = FactoryManager.WeaponFactory.CreateWeapon(weaponType);
        return weapon;
    }
}
