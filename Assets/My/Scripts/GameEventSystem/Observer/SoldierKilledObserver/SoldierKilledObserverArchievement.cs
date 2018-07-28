using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierKilledObserverArchievement : AbsGameEventObserver
{
    private ArchievementSystem archSystem;

    public SoldierKilledObserverArchievement(ArchievementSystem _archSystem)
    {
        archSystem = _archSystem;
    }

    public override void OnReceiveNotify()
    {
        archSystem.AddSoldierKilledCount();
    }

    public override void SetSubject(AbsGameEventSubject _subject)
    {
        
    }
}
