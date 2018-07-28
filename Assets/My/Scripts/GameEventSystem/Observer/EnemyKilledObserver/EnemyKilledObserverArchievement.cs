using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledObserverArchievement : AbsGameEventObserver
{
    //private EnemyKilledSubject subject;
    private ArchievementSystem archSystem;

    public EnemyKilledObserverArchievement(ArchievementSystem _archSystem)
    {
        archSystem = _archSystem;
    }

    public override void OnReceiveNotify()
    {
        archSystem.AddEnemyKilledCount();
    }

    public override void SetSubject(AbsGameEventSubject _subject)
    {
        //subject = _subject as EnemyKilledSubject; 
    }
}
