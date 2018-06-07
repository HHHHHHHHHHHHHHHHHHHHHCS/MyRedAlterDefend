using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCaptain : AbsSoldier
{
    public SoldierCaptain():base()
    {
        deadEffectName = "CaptainDeadEffect";
        deadSoundName = "CaptainDeath";
    }
}
