using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : ICharacterFactory
{
    public AbsCharacter CreateCharacter<T>(WeaponType _weaponType, Vector3 _pos, int _lv = 1) where T : AbsCharacter, new()
    {
        AbsCharacter character = new T();

        string name = "";
        int maxHP = 0;
        float moveSpeed = 0;
        string iconSprite = "";
        string prefabName = "";
        Type t = typeof(T);

        if(t==typeof(EnemyElf))
        {
            name = "小精灵";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "ElfIcon";
            prefabName = "Enemy1";
        }
        else if(t == typeof(EnemyOgre))
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
        CharacterAttr attr = new EnemyAttr(new EnemyAttrStrategy(), name, iconSprite, prefabName, maxHP, moveSpeed, _lv);
        GameObject characterGO = FactoryManager.AssetFactory.LoadEnemy(prefabName);
        characterGO.transform.position = _pos;
        AbsWeapon weapon = FactoryManager.WeaponFactory.CreateWeapon(_weaponType);

        character.OnInit(characterGO,attr,weapon) ;
        return character;
    }
}
