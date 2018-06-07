using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOgre : AbsEnemy
{
    public EnemyOgre() : base()
    {
        attackEffectName = "OgreHitEffect";
    }

    public override void Dead()
    {
        throw new NotImplementedException();
    }
}
