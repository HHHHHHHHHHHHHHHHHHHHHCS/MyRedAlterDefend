using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElf : AbsEnemy
{
    public EnemyElf() : base()
    {
        attackEffectName = "ElfHitEffect";
    }

    public override void Dead()
    {
        throw new NotImplementedException();
    }
}
