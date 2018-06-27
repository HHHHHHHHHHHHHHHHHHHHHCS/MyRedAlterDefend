using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSoldierCommand : ITrainCommand
{
    private SoldierType soldierType;
    private WeaponType weaponType;
    private Vector3 spawnPosition;
    private int lv;

    public TrainSoldierCommand(SoldierType _soldierType, WeaponType _weaponType, Vector3 _spawnPosition, int _lv)
    {
        soldierType = _soldierType;
        weaponType = _weaponType;
        spawnPosition = _spawnPosition;
        lv = _lv;
    }

    public void Execute()
    {
        switch (soldierType)
        {
            case SoldierType.Rookie:
                FactoryManager.SoldierFactory.CreateCharacter<SoldierRookie>(weaponType, spawnPosition, lv);
                break;
            case SoldierType.Sergeant:
                FactoryManager.SoldierFactory.CreateCharacter<SoldierSergeant>(weaponType, spawnPosition, lv);
                break;
            case SoldierType.Captain:
                FactoryManager.SoldierFactory.CreateCharacter<SoldierCaptain>(weaponType, spawnPosition, lv);
                break;
            default:
                break;
        }
    }
}
