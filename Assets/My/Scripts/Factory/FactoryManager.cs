using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FactoryManager
{
    private static IAssetFactory _assetFactory;
    private static ICharacterFactory _soldierFactory;
    private static ICharacterFactory _enemyFactory;
    private static IWeaponFactory _weaponFactory;
    private static IAttrFactory _attrFactory;

    public static IAssetFactory AssetFactory
    {
        get
        {
            if (_assetFactory == null)
            {
                _assetFactory = new ResourcesAssetProxyFactory();
            }
            return _assetFactory;
        }
    }

    public static ICharacterFactory SoldierFactory
    {
        get
        {
            if (_soldierFactory == null)
            {
                _soldierFactory = new SoldierFactory();
            }
            return _soldierFactory;
        }
    }

    public static ICharacterFactory EnemyFactory
    {
        get
        {
            if (_enemyFactory == null)
            {
                _enemyFactory = new EnemyFactory();
            }
            return _enemyFactory;
        }
    }

    public static IWeaponFactory WeaponFactory
    {
        get
        {
            if (_weaponFactory == null)
            {
                _weaponFactory = new WeaponFactory();
            }
            return _weaponFactory;
        }
    }

    public static IAttrFactory AttrFactory
    {
        get
        {
            if (_attrFactory == null)
            {
                _attrFactory = new AttrFactory();
            }
            return _attrFactory;
        }
    }
}
