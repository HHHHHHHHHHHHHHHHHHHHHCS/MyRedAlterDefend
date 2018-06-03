using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : AbsEnemyState
{
    public EnemyAttackState(EnemySatateSystem _fsm, AbsCharacter _character) : base(_fsm, _character)
    {
    }

    public override void Act(List<AbsCharacter> targetList)
    {
        throw new NotImplementedException();
    }

    public override void Reason(List<AbsCharacter> targetList)
    {
        throw new NotImplementedException();
    }
}
