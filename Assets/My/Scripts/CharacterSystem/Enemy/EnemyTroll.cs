﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTroll : AbsEnemy
{
    public EnemyTroll() : base()
    {
        attackEffectName = "TrollHitEffect";
    }

    public override void Dead()
    {
        throw new NotImplementedException();
    }
}
