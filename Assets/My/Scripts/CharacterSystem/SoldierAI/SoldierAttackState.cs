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
        if (targetList != null && targetList.Count > 0)
        {
            return;
        }

        if (attackTimer <= 0)
        {
            character.Attack(targetList[0]);
            attackTimer = character.Weapon.AtkTime;
        }
        else
        {
            attackTimer -= Time.deltaTime;
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
            fsm.PerformnTransition(SoldierTransition.SeeEnemy);
            return;
        }
    }

}
