using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : AbsGameSystem
{
    private int nowLv ;
    private List<Vector3> spawnPosList;
    private Dictionary<int, IStageHandler> stageHandlerDic;
    private IStageHandler nowHandler;
    private int killedCount;

    public int NowLv
    {
        get
        {
            return nowLv;
        }

        private set
        {
            nowLv = value;
            GameFacade.Instance.UpdateNowStage(value);
        }
    }

    public override void OnInit()
    {
        spawnPosList = new List<Vector3>();
        OnInitSpawnPosList();
        OnInitStageChain();

        NowLv = 1;
        nowHandler = GetHandlerByLV(NowLv);
        GameFacade.Instance.RegisterObserver(GameEventType.EnemyKilled
            , new EnemyyKilledObserverStageSystem(this));
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

    private void OnInitStageChain()
    {
        stageHandlerDic = new Dictionary<int, IStageHandler>();

        int lv = 0;
        int count = 3;
        AddDic(new NormalStageHandler(++lv, EnemyType.Elf, WeaponType.Gun, count * lv, spawnPosList, count * lv));
        AddDic(new NormalStageHandler(++lv, EnemyType.Elf, WeaponType.Rifle, count * lv, spawnPosList, count * lv));
        AddDic(new NormalStageHandler(++lv, EnemyType.Elf, WeaponType.Rocket, count * lv, spawnPosList, count * lv));
        AddDic(new NormalStageHandler(++lv, EnemyType.Ogre, WeaponType.Gun, count * lv, spawnPosList, count * lv));
        AddDic(new NormalStageHandler(++lv, EnemyType.Ogre, WeaponType.Rifle, count * lv, spawnPosList, count * lv));
        AddDic(new NormalStageHandler(++lv, EnemyType.Ogre, WeaponType.Rocket, count * lv, spawnPosList, count * lv));
        AddDic(new NormalStageHandler(++lv, EnemyType.Troll, WeaponType.Gun, count * lv, spawnPosList, count * lv));
        AddDic(new NormalStageHandler(++lv, EnemyType.Troll, WeaponType.Rifle, count * lv, spawnPosList, count * lv));
        AddDic(new NormalStageHandler(++lv, EnemyType.Troll, WeaponType.Rocket, count * lv, spawnPosList, count * lv));
    }

    private void AddDic(IStageHandler ish)
    {
        stageHandlerDic.Add(ish.lv, ish);
    }

    public void AddEnemyKilled()
    {
        killedCount++;
        GameFacade.Instance.TriggerEvent(GameEventType.EnemyKilled);
    }

    public int GetCountOfEnemyKilled()
    {
        return killedCount;
    }

    public override void OnUpdate()
    {
        if (nowHandler != null)
        {
            if (!nowHandler.CheckIsFinised())
            {
                nowHandler.UpdateStage();
            }
            else
            {
                GameFacade.Instance.TriggerEvent(GameEventType.NewStage);
                NowLv++;
                nowHandler = GetHandlerByLV(NowLv);
            }
        }
    }

    public IStageHandler GetHandlerByLV(int _nowLv)
    {
        IStageHandler _nowHandler = null;
        if (stageHandlerDic.TryGetValue(_nowLv,out _nowHandler))
        {
            return _nowHandler;
        }
        else
        {
            Debug.Log("GetHandlerByLV is null");
            return null;
        }
    }
}

