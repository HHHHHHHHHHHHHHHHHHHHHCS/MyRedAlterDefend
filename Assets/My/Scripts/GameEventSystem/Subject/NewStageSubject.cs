using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageSubject : AbsGameEventSubject
{
    private int stageCount = 1;

    public int StageCount { get { return stageCount; } }

    public override void TriggerEvent()
    {
        stageCount++;
        NotifyObserver();
    }

}
