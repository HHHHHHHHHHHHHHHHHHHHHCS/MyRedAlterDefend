using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageSubject : AbsGameEventSubject
{
    public int StageCount { get { return GameFacade.Instance.StageSystem.NowLv; } }

    public override void TriggerEvent()
    {
        NotifyObserver();
    }

}
