using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : IWeaponFactory
{
    public AbsWeapon CreateWeapon(WeaponType _type)
    {
        AbsWeapon weapon = null;
        WeaponBaseAttr attr = FactoryManager.AttrFactory.GetWeaponBaseAttr(_type);
        GameObject weaponGO = FactoryManager.AssetFactory.LoadWeapon(attr.AssetName);
        switch (_type)
        {
            case WeaponType.Gun:
                weapon = new WeaponGun(attr, weaponGO);
                break;
            case WeaponType.Rifle:
                weapon = new WeaponRifle(attr, weaponGO);
                break;
            case WeaponType.Rocket:
                weapon = new WeaponRocket(attr, weaponGO);
                break;
            default:
                break;
        }
        return weapon;
    }
}
