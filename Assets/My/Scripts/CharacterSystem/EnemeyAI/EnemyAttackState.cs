using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : AbsEnemyState
{
    private float attackTimer = 0;

    public EnemyAttackState(EnemySatateSystem _fsm, AbsCharacter _character) : base(_fsm, _character)
    {
        StateID = EnemyStateID.Attack;
    }

    public override void Act(List<AbsCharacter> targetList)
    {
        if (attackTimer >= 0)
        {
            attackTimer -= Time.deltaTime;
        }

        if (targetList != null && targetList.Count > 0)
        {
            return;
        }

        if (attackTimer <= 0)
        {
            character.Attack(targetList[0]);
            attackTimer = character.Weapon.AtkTime;
        }
    }

    public override void Reason(List<AbsCharacter> targetList)
    {
        if(targetList==null||targetList.Count<=0)
        {
            fsm.PerformnTransition(EnemyTransition.LostSoldier);
        }
        else
        {
            Vector3 pos = targetList[0].Position;
            if (Vector3.Distance(character.Position, pos) > character.Weapon.AtkRange)
            {
                fsm.PerformnTransition(EnemyTransition.LostSoldier);
            }
        }
    }
}
