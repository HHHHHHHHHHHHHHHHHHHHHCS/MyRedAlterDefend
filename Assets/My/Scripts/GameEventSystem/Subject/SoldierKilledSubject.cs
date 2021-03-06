﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierKilledSubject : AbsGameEventSubject
{
    private int killedCount = 0;

    public int KilledCount { get { return killedCount; } }

    public override void TriggerEvent()
    {
        killedCount++;
        NotifyObserver();
    }
}
