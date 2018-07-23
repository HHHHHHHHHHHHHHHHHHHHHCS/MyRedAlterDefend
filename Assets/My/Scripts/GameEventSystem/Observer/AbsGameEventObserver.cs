using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsGameEventObserver
{
    public AbsGameEventSubject Subject { get; set; }


    public void OnReceiveNotify()
    {

    }
}
