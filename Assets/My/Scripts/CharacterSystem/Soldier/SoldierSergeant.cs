using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSergeant : AbsSoldier
{
    public SoldierSergeant() : base()
    {
        deadEffectName = "SergeantDeadEffect";
        deadSoundName = "SergeantDeath";
    }

}
