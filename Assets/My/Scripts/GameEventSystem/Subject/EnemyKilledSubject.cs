using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledSubject : AbsGameEventSubject
{
    public int KilledCount { get; set; }

    public override void TriggerEvent()
    {
        NotifyObserver();
    }
}
