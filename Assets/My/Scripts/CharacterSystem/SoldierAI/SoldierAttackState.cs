using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttackState : AbsSoldierState
{
    private float attackTimer = 0;

    public SoldierAttackState(SoldierSatateSystem _fsm, AbsCharacter _character)
        : base(_fsm, _character)
    {
        StateID = SoldierStateID.Attack;
    }

    public override void Act(List<AbsCharacter> targetList)
    {
        if(attackTimer >= 0)
        {
            attackTimer -= Time.deltaTime;
            return;
        }

        if (targetList != null && targetList.Count <= 0)
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
        if (targetList == null || targetList.Count == 0)
        {
            fsm.PerformnTransition(SoldierTransition.NoEnemy);
            return;
        }
        if (targetList != null && targetList.Count > 0)
        {
            float distance = Vector3.Distance(targetList[0].Position, character.Position);
            if (distance > character.Weapon.AtkRange)
            {
                fsm.PerformnTransition(SoldierTransition.SeeEnemy);
                return;
            }
        }
    }

}
