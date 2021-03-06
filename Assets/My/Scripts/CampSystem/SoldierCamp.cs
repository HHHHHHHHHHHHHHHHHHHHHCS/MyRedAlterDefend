﻿using System;
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
        UpgradeEnergyCostStrategy();
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

    public override bool Train()
    {
        int energy = EnergyCostSoldierTrain;
        if (energy < 0)
        {
            GameFacade.Instance.ShowTipMessage("训练错误!");
            return false;
        }
        if (GameFacade.Instance.UseEnergy(energy))
        {
            TrainSoldierCommand cmd = new TrainSoldierCommand(SoldierType, WeaponType, Position, LV);
            cmdList.AddLast(cmd);
            return true;
        }
        else
        {
            GameFacade.Instance.ShowTipMessage("训练士兵能量不足,需要能量:" + energy);
        }
        return false;
    }

    public override bool UpgradeCamp()
    {
        int energy = EnergyCostCampUpgrade;
        if (energy < 0)
        {
            GameFacade.Instance.ShowTipMessage("军营已经满级");
            return false;
        }
        if( GameFacade.Instance.UseEnergy(energy))
        {
            nowLv = Mathf.Min(nowLv + 1, MaxLv);
            UpgradeEnergyCostStrategy();
            GameFacade.Instance.ShowTipMessage("军营升级成功");
            return true;
        }
        else
        {
            GameFacade.Instance.ShowTipMessage("军营升级能量不足,需要能量:" + energy);
        }
        return false;
    }

    public override bool UpgradeWeapon()
    {
        int energy = EnergyCostWeaponUpgrade;

        if (energy < 0)
        {
            GameFacade.Instance.ShowTipMessage("武器已经满级");
            return false;
        }
        if (GameFacade.Instance.UseEnergy(energy))
        {
            weaponType = (WeaponType)Mathf.Clamp((int)weaponType + 1, 0, maxWeaponLV);
            UpgradeEnergyCostStrategy();
            GameFacade.Instance.ShowTipMessage("武器升级成功");
            return true;
        }
        else
        {
            GameFacade.Instance.ShowTipMessage("武器升级能量不足,需要能量:"+ energy);
        }
        return false;
    }

    protected override void UpgradeEnergyCostStrategy()
    {
        energyCostCampUpgrade = energyCostStrategy.GetCampUpgradeCost(SoldierType, LV);
        energyCostWeaponUpgrade = energyCostStrategy.GetWeaponUpgradeCost(WeaponType);
        energyCostTrain = energyCostStrategy.GetTrainSoldierCost(SoldierType, LV);
    }
}
