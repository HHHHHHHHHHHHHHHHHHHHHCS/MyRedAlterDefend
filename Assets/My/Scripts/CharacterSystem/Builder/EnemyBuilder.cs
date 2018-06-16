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

        string name = "";
        int maxHP = 0;
        float moveSpeed = 0;
        string iconSprite = "";
        string prefabName = "";
        if (t == typeof(EnemyElf))
        {
            name = "小精灵";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "ElfIcon";
            prefabName = "Enemy1";
        }
        else if (t == typeof(EnemyOgre))
        {
            name = "怪物";
            maxHP = 120;
            moveSpeed = 4;
            iconSprite = "OgreIcon";
            prefabName = "Enemy2";
        }
        else if (t == typeof(EnemyTroll))
        {
            name = "巨魔";
            maxHP = 240;
            moveSpeed = 1;
            iconSprite = "TrollIcon";
            prefabName = "Enemy3";
        }
        CharacterAttr attr = new EnemyAttr(new EnemyAttrStrategy(), name, iconSprite, prefabName, maxHP, moveSpeed, lv);
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
