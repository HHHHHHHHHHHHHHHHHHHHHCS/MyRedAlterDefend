using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder : AbsCharacterBuilder
{
    private float critRate;

    public EnemyBuilder(AbsCharacter _character, Type _t, WeaponType _weaponType
    , Vector3 _spawnPosition, int _lv,float _critRate)
        : base(_character, _t, _weaponType, _spawnPosition, _lv)
    {
        critRate = _critRate;
    }

    public override CharacterAttr AddCharacterAttr()
    {

        CharacterBaseAttr baseAttr = FactoryManager.AttrFactory.GetCharacterBaseAttr(t);
        EnemyAttr attr = new EnemyAttr(new SoldierAttrStrategy(), baseAttr,lv, critRate);
        return attr;
    }

    public override GameObject AddGameObject()
    {
        return FactoryManager.AssetFactory.LoadEnemy(prefabName);
    }

    public override AbsWeapon AddWeapon()
    {
        return FactoryManager.WeaponFactory.CreateWeapon(weaponType);
    }
}
