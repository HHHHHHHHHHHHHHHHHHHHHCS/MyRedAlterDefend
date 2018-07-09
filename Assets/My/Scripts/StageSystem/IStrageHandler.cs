using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IStageHandler
{
    protected int countToFinish;
    protected int lv;

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

    protected virtual void UpdateStage()
    {

    }
}
