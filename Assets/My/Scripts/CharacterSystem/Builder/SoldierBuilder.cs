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
        CharacterBaseAttr baseAttr = FactoryManager.AttrFactory.GetCharacterBaseAttr(t);
        SoldierAttr attr = new SoldierAttr(new SoldierAttrStrategy(), baseAttr,lv);
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
