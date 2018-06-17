using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : ICharacterFactory
{
    public AbsCharacter CreateCharacter<T>(WeaponType _weaponType, Vector3 _pos, int _lv = 1) where T : AbsCharacter, new()
    {
        AbsCharacter character = new T();
        AbsCharacterBuilder builder = new SoldierBuilder(character, typeof(T), _weaponType, _pos, _lv);
        return CharacterBuilderDirector.Construct(builder);
    }
}
