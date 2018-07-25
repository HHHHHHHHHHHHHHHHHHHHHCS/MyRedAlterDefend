using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsGameEventObserver
{

    public abstract void OnReceiveNotify();

    public abstract void SetSubject(AbsGameEventSubject _subject);
}
