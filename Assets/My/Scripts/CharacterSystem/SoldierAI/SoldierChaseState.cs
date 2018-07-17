using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierChaseState : AbsSoldierState
{
    public SoldierChaseState(SoldierSatateSystem _fsm, AbsCharacter _character) 
        : base(_fsm, _character)
    {
        StateID = SoldierStateID.Chase;
    }

    public override void Act(List<AbsCharacter> targetList)
    {
        if (targetList != null && targetList.Count > 0)
        {
            character.MoveTo(targetList[0].Position);
        }
    }

    public override void Reason(List<AbsCharacter> targetList)
    {
        if (targetList == null || targetList.Count == 0)
        {
            fsm.PerformnTransition(SoldierTransition.NoEnemy);
            return;
        }
        float distance = Vector3.Distance(targetList[0].Position, character.Position);
        if(distance<=character.Weapon.AtkRange)
        {
            fsm.PerformnTransition(SoldierTransition.CanAttack);
        }
    }


}
