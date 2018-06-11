using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : IWeaponFactory
{
    public AbsWeapon CreateWeapon(WeaponType _type)
    {
        AbsWeapon weapon = null;
        string assetName = "";
        switch (_type)
        {
            case WeaponType.Gun:
                assetName = "WeaponGun";
                break;
            case WeaponType.Rifle:
                assetName = "WeaponRifle";
                break;
            case WeaponType.Rocket:
                assetName = "WeaponRocket";
                break;
            default:
                break;
        }
        IAssetFactory factory = new ResourcesFactory();
        GameObject weaponGO = factory.LoadWeapon(assetName);
        switch (_type)
        {
            case WeaponType.Gun:
                weapon = new WeaponGun(20, 5,0.5f, weaponGO);
                break;
            case WeaponType.Rifle:
                weapon = new WeaponGun(30, 7.5f,1f, weaponGO);
                break;
            case WeaponType.Rocket:
                weapon = new WeaponGun(40, 10,1.5f, weaponGO);
                break;
            default:
                break;
        }
        return weapon;
    }
}
