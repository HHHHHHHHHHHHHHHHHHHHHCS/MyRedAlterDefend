using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCaptiveCommand : ITrainCommand
{
    private EnemyType enemyType;
    private WeaponType weaponType;
    private Vector3 posistion;

    public TrainCaptiveCommand(EnemyType _enemyType, WeaponType _weaponType
        , Vector3 _posistion)
    {
        enemyType = _enemyType;
        weaponType = _weaponType;
        posistion = _posistion;
    }

    public void Execute()
    {
        AbsEnemy enemy = null;
        switch (enemyType)
        {
            case EnemyType.Elf:
                enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyElf>(weaponType, posistion);
                break;
            case EnemyType.Ogre:
                enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyOgre>(weaponType, posistion);
                break;
            case EnemyType.Troll:
                enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyTroll>(weaponType, posistion);
                break;
            default:
                Debug.Log("无法创建俘兵");
                break;
        }
        GameFacade.Instance.CharacterSystem.RemoveEnemy(enemy);
        SoliderCaptiver captiver = new SoliderCaptiver(enemy);
        GameFacade.Instance.CharacterSystem.AddSoldier(captiver);
    }
}
