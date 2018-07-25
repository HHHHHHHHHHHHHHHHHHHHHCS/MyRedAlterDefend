using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class EnemyyKilledObserverStageSystem : AbsGameEventObserver
{
    private EnemyKilledSubject subject;
    private StageSystem ss;

    public EnemyyKilledObserverStageSystem(StageSystem _ss)
    {
        ss = _ss;
    }

    public override void OnReceiveNotify()
    {
        subject.KilledCount = ss.GetCountOfEnemyKilled();
    }

    public override void SetSubject(AbsGameEventSubject _subject)
    {
        subject = _subject as EnemyKilledSubject;
    }
}

