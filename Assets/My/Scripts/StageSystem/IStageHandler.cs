using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IStageHandler
{
    protected int countToFinish;
    public int lv { get; protected set; }

    public IStageHandler(int _lv,int _countToFinish)
    {
        lv = _lv;
        countToFinish = _countToFinish;
    }

    public bool Handle(int level)
    {
        if(level==lv)
        {
            UpdateStage();
            return true;
        }
        return false;
    }

    public abstract void UpdateStage();

    public abstract bool CheckIsFinised();
}
