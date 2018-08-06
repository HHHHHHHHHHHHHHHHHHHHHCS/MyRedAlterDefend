using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptiveCamp : AbsCamp
{
    private WeaponType weaponType = WeaponType.Gun;
    private EnemyType enemyType;
    private int energyCostSoldierTrain;

    public override int LV
    {
        get
        {
            return 1;
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
            return 0;
        }
    }


    public override int EnergyCostWeaponUpgrade
    {
        get
        {
            return 0;
        }
    }


    public override int EnergyCostSoldierTrain
    {
        get
        {
            return energyCostTrain;
        }
    }


    public CaptiveCamp(GameObject _gameObject, string _name, string _iconSprite, EnemyType _enemyType, Vector3 _position, float _trainTime)
        : base(_gameObject, _name, _iconSprite, SoldierType.Captive, _position, _trainTime)
    {
        energyCostStrategy = new SoldierEnergyCostStrategy();
        enemyType = _enemyType;
        UpgradeEnergyCostStrategy();
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
            TrainCaptiveCommand cmd = new TrainCaptiveCommand(enemyType, WeaponType, Position);
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
        return false;
    }

    public override bool UpgradeWeapon()
    {
        return false;
    }

    protected override void UpgradeEnergyCostStrategy()
    {
        energyCostTrain = energyCostStrategy.GetTrainSoldierCost(SoldierType, 1);
    }
}
