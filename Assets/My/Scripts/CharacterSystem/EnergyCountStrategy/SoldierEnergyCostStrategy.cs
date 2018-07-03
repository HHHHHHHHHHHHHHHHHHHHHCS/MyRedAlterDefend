using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierEnergyCostStrategy : IEnergyCostStrategy
{
    public int GetCampUpgradeCost(SoldierType _type, int _lv)
    {
        int energy = 0;
        switch (_type)
        {
            case SoldierType.Rookie:
                energy = 60;
                break;
            case SoldierType.Sergeant:
                energy = 65;
                break;
            case SoldierType.Captain:
                energy = 70;
                break;
        }
        energy += (_lv - 1) * 2;
        energy = Mathf.Clamp(energy, 0, 100);
        return energy;
    }

    public int GetTrainSoldierCost(SoldierType _type, int _lv)
    {
        int energy = 0;
        switch (_type)
        {
            case SoldierType.Rookie:
                energy = 10;
                break;
            case SoldierType.Sergeant:
                energy = 15;
                break;
            case SoldierType.Captain:
                energy = 20;
                break;
            default:
                break;
        }
        energy += (_lv - 1) * 2;
        energy = Mathf.Clamp(energy, 0, 100);
        return energy;
    }

    public int GetWeaponUpgradeCost(WeaponType _type)
    {
        int energy = 0;
        switch (_type)
        {
            case WeaponType.Gun:
                energy = 40;
                break;
            case WeaponType.Rifle:
                energy = 60;
                break;
        }
        return energy;
    }
}
