using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FactoryManager
{
    private static IAssetFactory _assetFactory;
    private static ICharacterFactory _soldierFactory;
    private static ICharacterFactory _enemyFactory;
    private static IWeaponFactory _weaponFactory;

    public static IAssetFactory AssetFactory
    {
        get
        {
            if (_assetFactory == null)
            {
                _assetFactory = new ResourcesFactory();
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
}
