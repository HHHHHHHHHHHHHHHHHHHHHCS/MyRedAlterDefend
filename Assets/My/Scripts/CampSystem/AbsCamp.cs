using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsCamp
{
    public static CampInfoUI NowCampUI;

    public GameObject GameObject;
    public string Name;
    public string IconSprite;
    public SoldierType SoldierType;
    public Vector3 Position;
    public float TrainTime;

    protected LinkedList<ITrainCommand> cmdList;
    protected float trainTimer;


    public virtual int TrainQueueCount
    {
        get
        {
            return cmdList.Count;
        }

    }

    public virtual float LastTrainTimer
    {
        get
        {
            return cmdList.Count == 0 ? 0 : trainTimer;
        }
    }

    public AbsCamp(GameObject _gameObject, string _name, string _iconSprite
        , SoldierType _soldierType, Vector3 _position, float _trainTime)
    {
        GameObject = _gameObject; ;
        Name = _name;
        IconSprite = _iconSprite;
        SoldierType = _soldierType;
        Position = _position;
        TrainTime = _trainTime;
        trainTimer = _trainTime;
        cmdList = new LinkedList<ITrainCommand>();
    }

    public virtual void OnUpdate()
    {
        UpdateCommand();
    }

    protected virtual void UpdateCommand()
    {
        if (cmdList.Count > 0 && trainTimer > 0)
        {
            trainTimer -= Time.deltaTime;
            if (trainTimer <= 0)
            {
                cmdList.First.Value.Execute();
                cmdList.RemoveFirst();
            }
            UpdatgeCampInfo();
        }

        if ((cmdList.Count > 0 && trainTimer <= 0)
            || (cmdList.Count <= 0 && trainTimer != TrainTime))
        {
            trainTimer = TrainTime;
            UpdatgeCampInfo();
        }
    }

    public abstract int LV { get; }
    public abstract WeaponType WeaponType { get; }
    public abstract void Train();
    public virtual void CancelTrain()
    {
        //能量的回收
        if (cmdList.Count > 0)
        {
            cmdList.RemoveLast();
            UpdatgeCampInfo();
        }
    }

    public virtual void UpdatgeCampInfo()
    {
        if (NowCampUI != null)
        {
            NowCampUI.UpdateInfo();
        }
    }
}
