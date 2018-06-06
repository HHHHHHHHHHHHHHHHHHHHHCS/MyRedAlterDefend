using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElf : AbsEnemy
{
    protected override void PlayAttackEffect()
    {
        DoPlayEffect("ElfHitEffect");
    }
}
