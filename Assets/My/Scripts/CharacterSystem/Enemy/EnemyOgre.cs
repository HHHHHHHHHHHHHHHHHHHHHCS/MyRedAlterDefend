using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOgre : AbsEnemy
{
    protected override void PlayAttackEffect()
    {
        DoPlayEffect("OgreHitEffect");
    }
}
