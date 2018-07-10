using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStageHandler : IStageHandler
{
    private EnemyType enemyType;
    private WeaponType weaponType;
    private int count;
    private Vector3 position;

    private float spawnTime = 1;
    private float spawnTimer = 0;
    private int countSpawned = 0; 

    public NormalStageHandler(int _lv, EnemyType _enemyType, WeaponType _weaponType
        , int _count, Vector3 _position, int _countToFinish)
        :base (_lv,_countToFinish)
    {
        enemyType = _enemyType;
        weaponType = _weaponType;
        count = _count;
        position = _position;
    }

    protected override void UpdateStage()
    {
        base.UpdateStage();
        if(countSpawned<count)
        {
            spawnTimer -= Time.deltaTime;
            if(spawnTimer<=0)
            {
                SpawnEnemy();
                spawnTimer = spawnTime;
            }
        }
    }

    public bool CheckIsFinised()
    {
        return GameFacade.Instance.StageSystem.GetCountOfEnemyKilled() >= countToFinish;
    }

    public void SpawnEnemy()
    {
        countSpawned++;
        switch (enemyType)
        {
            case EnemyType.Elf:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyElf>(weaponType,position,lv);
                break;
            case EnemyType.Ogre:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyOgre>(weaponType, position, lv);
                break;
            case EnemyType.Troll:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyTroll>(weaponType, position, lv);
                break;
            default:
                Debug.Log("无法生成敌人,敌人的类型为:" + enemyType);
                break;
        }
    }
}
