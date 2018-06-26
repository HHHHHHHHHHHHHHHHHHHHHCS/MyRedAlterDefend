using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCamp : AbsCamp
{
    private const int MaxLv = 10;
    private int nowLv = 1;
    private WeaponType weaponType = WeaponType.Gun;

    public SoldierCamp(GameObject _gameObject, string _name, string _iconSprite, SoldierType _soldierType, Vector3 _position, float _trainTime, int _lv = 1, WeaponType _weaponType = WeaponType.Gun)
        : base(_gameObject, _name, _iconSprite, _soldierType, _position, _trainTime)
    {
        nowLv = _lv;
        weaponType = _weaponType;
    }

    public override int LV
    {
        get
        {
            return nowLv;
        }
    }

    public override WeaponType WeaponType
    {
        get
        {
            return weaponType;
        }
    }
}
