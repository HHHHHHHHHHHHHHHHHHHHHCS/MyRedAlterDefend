using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : ICharacterFactory
{
    public AbsCharacter CreateCharacter<T>(WeaponType _weaponType, Vector3 _pos, int _lv = 1) where T : AbsCharacter, new()
    {
        AbsCharacter character = new T();

        //创建角色游戏物体

        return null;
    }
}
