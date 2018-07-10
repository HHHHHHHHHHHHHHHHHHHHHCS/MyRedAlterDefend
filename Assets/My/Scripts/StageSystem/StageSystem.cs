using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : AbsGameSystem
{
    private int nowLv = 1;
    private List<Vector3> spawnPosList;
    private Dictionary<int, IStageHandler> stageHandlerDic;

    public override void OnInit()
    {
        spawnPosList = new List<Vector3>();
        OnInitStageChain();
    }

    private void OnInitSpawnPosList()
    {
        spawnPosList = new List<Vector3>();
        for (int i = 1; i < int.MaxValue; i++)
        {
            GameObject go = GameObject.Find("EnemyPosition/Position" + i);
            if (go != null)
            {
                spawnPosList.Add(go.transform.position);
            }
            else
            {
                break;
            }
        }
    }

    private Vector3 GetRandomPos()
    {
        if (spawnPosList == null || spawnPosList.Count == 0)
        {
            Debug.Log("spawnPosList is null or count==0");
            return Vector3.zero;
        }
        return spawnPosList[UnityEngine.Random.Range(0, spawnPosList.Count)];
    }

    private void OnInitStageChain()
    {
        stageHandlerDic = new Dictionary<int, IStageHandler>();

        int lv = 1;
        int count = 3;
        AddDic(new NormalStageHandler(lv++, EnemyType.Elf, WeaponType.Gun, count * lv, GetRandomPos(), count * lv));
        AddDic(new NormalStageHandler(lv++, EnemyType.Elf, WeaponType.Rifle, count * lv, GetRandomPos(), count * lv));
        AddDic(new NormalStageHandler(lv++, EnemyType.Elf, WeaponType.Rocket, count * lv, GetRandomPos(), count * lv));
        AddDic(new NormalStageHandler(lv++, EnemyType.Ogre, WeaponType.Gun, count * lv, GetRandomPos(), count * lv));
        AddDic(new NormalStageHandler(lv++, EnemyType.Ogre, WeaponType.Rifle, count * lv, GetRandomPos(), count * lv));
        AddDic(new NormalStageHandler(lv++, EnemyType.Ogre, WeaponType.Rocket, count * lv, GetRandomPos(), count * lv));
        AddDic(new NormalStageHandler(lv++, EnemyType.Troll, WeaponType.Gun, count * lv, GetRandomPos(), count * lv));
        AddDic(new NormalStageHandler(lv++, EnemyType.Troll, WeaponType.Rifle, count * lv, GetRandomPos(), count * lv));
        AddDic(new NormalStageHandler(lv++, EnemyType.Troll, WeaponType.Rocket, count * lv, GetRandomPos(), count * lv));


    }

    private void AddDic(IStageHandler ish)
    {
        stageHandlerDic.Add(ish.lv, ish);
    }

    public int GetCountOfEnemyKilled()
    {
        return 0;
    }
}

