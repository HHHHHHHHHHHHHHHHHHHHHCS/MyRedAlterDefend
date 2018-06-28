using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsCharacterBuilder
{
    public AbsCharacter Character { get; protected set; }
    public Vector3 spawnPosition { get; protected set; }

    protected Type t;
    protected WeaponType weaponType;
    protected int lv;


    public AbsCharacterBuilder(AbsCharacter _character, Type _t, WeaponType _weaponType
        , Vector3 _spawnPosition, int _lv)
    {
        Character = _character;
        t = _t;
        weaponType = _weaponType;
        spawnPosition = _spawnPosition;
        lv = _lv;
    }

    public abstract CharacterAttr AddCharacterAttr();
    public abstract GameObject AddGameObject(CharacterAttr attr);
    public abstract AbsWeapon AddWeapon();
    public virtual AbsCharacter GetResult()
    {
        return Character;
    }
}
