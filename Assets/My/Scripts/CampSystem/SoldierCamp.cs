using System;
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
        energyCostStrategy = new SoldierEnergyCostStrategy();
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

    public override int EnergyCostCampUpgrade
    {
        get
        {
            if (LV == MaxLv)
            {
                return -1;
            }
            return energyCostCampUpgrade;
        }
    }

    public override int EnergyCostWeaponUpgrade
    {
        get
        {
            if ((int)weaponType == maxWeaponLV)
            {
                return -1;
            }
            return energyCostWeaponUpgrade;
        }
    }


    public override int EnergyCostSoldierTrain
    {
        get
        {
            return energyCostTrain;
        }
    }

    public override void Train()
    {
        UpgradeEnergyCostStrategy();
        //要判断能量是否够用
        TrainSoldierCommand cmd = new TrainSoldierCommand(SoldierType, WeaponType, Position, LV);
        cmdList.AddLast(cmd);
    }

    public override void UpgradeCamp()
    {
        UpgradeEnergyCostStrategy();
        nowLv = Mathf.Min(nowLv + 1, MaxLv);
    }

    public override void UpgradeWeapon()
    {
        UpgradeEnergyCostStrategy();
        weaponType = (WeaponType)Mathf.Clamp((int)weaponType + 1, 0, maxWeaponLV);
    }

    protected override void UpgradeEnergyCostStrategy()
    {
        energyCostCampUpgrade = energyCostStrategy.GetCampUpgradeCost(SoldierType, LV);
        energyCostWeaponUpgrade = energyCostStrategy.GetWeaponUpgradeCost(WeaponType);
        energyCostTrain = energyCostStrategy.GetTrainSoldierCost(SoldierType, LV);
    }
}
