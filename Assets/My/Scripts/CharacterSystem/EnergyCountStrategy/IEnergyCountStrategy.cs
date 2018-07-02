using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 能量消耗策略基类
/// </summary>
public interface IEnergyCountStrategy
{
    int GetCampUpgradeCost( SoldierType _type, int _lv);
    int GetWeaponUpgradeCost(WeaponType _type);
    int GetTrainSoldierCost( SoldierType _type, int _lv);
}
