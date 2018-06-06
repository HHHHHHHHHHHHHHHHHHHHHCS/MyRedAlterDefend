using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTroll : AbsEnemy
{
    protected override void PlayAttackEffect()
    {
        DoPlayEffect("TrollHitEffect");
    }
}
