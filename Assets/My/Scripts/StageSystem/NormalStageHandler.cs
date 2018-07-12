using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStageHandler : IStageHandler
{
    private EnemyType enemyType;
    private WeaponType weaponType;
    private int count;

    private float spawnTime = 1;
    private float spawnTimer = 0;
    private int countSpawned = 0;
    private List<Vector3> spawnPosList;

    public NormalStageHandler(int _lv, EnemyType _enemyType, WeaponType _weaponType
        , int _count, List<Vector3> _spawnPosList, int _countToFinish)
        :base (_lv,_countToFinish)
    {
        enemyType = _enemyType;
        weaponType = _weaponType;
        count = _count;
        spawnPosList = _spawnPosList;
    }

    private Vector3 GetRandomPos()
    {
        if (spawnPosList == null || spawnPosList.Count == 0)
        {
            Debug.Log("spawnPosList is null or count==0");
            return Vector3.zero;
        }
        return spawnPosList[Random.Range(0, spawnPosList.Count)];
    }

    public override void UpdateStage()
    {
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

    public override bool CheckIsFinised()
    {
        return GameFacade.Instance.StageSystem.GetCountOfEnemyKilled() >= countToFinish;
    }

    public void SpawnEnemy()
    {
        countSpawned++;
        switch (enemyType)
        {
            case EnemyType.Elf:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyElf>(weaponType, GetRandomPos(), lv);
                break;
            case EnemyType.Ogre:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyOgre>(weaponType, GetRandomPos(), lv);
                break;
            case EnemyType.Troll:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyTroll>(weaponType, GetRandomPos(), lv);
                break;
            default:
                Debug.Log("无法生成敌人,敌人的类型为:" + enemyType);
                break;
        }

    }
}
