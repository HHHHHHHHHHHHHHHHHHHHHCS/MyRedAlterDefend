using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder : AbsCharacterBuilder
{
    public EnemyBuilder(AbsCharacter _character, Type _t, WeaponType _weaponType
    , Vector3 _spawnPosition, int _lv)
        : base(_character, _t, _weaponType, _spawnPosition, _lv)
    {
    }

    public override CharacterAttr AddCharacterAttr()
    {
        CharacterBaseAttr baseAttr = FactoryManager.AttrFactory.GetCharacterBaseAttr(t);
        EnemyAttr attr = new EnemyAttr(new SoldierAttrStrategy(), baseAttr, lv, baseAttr.CritRate);
        return attr;
    }

    public override GameObject AddGameObject(CharacterAttr attr)
    {
        return FactoryManager.AssetFactory.LoadEnemy(attr.PrefabName);
    }

    public override AbsWeapon AddWeapon()
    {
        return FactoryManager.WeaponFactory.CreateWeapon(weaponType);
    }
}
