using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageOvserverArchievement : AbsGameEventObserver
{
    private NewStageSubject subject;
    private ArchievementSystem archSystem;

    public NewStageOvserverArchievement(ArchievementSystem _archSystem)
    {
        archSystem = _archSystem;
    }

    public override void OnReceiveNotify()
    {
        archSystem.SetMaxStageLv(subject.StageCount);
    }

    public override void SetSubject(AbsGameEventSubject _subject)
    {
        subject = _subject as NewStageSubject;
    }
}
