using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierIdleState : AbsSoldierState
{
    public SoldierIdleState(SoldierSatateSystem _fsm, AbsCharacter _character) 
        : base(_fsm, _character)
    {
        StateID = SoldierStateID.Idle;
    }

    public override void Act(List<AbsCharacter> targetList)
    {
        character.PlayAnim("stand");
    }

    public override void Reason(List<AbsCharacter> targetList)
    {
        if (targetList != null && targetList.Count > 0)
        {
            fsm.PerformnTransition(SoldierTransition.SeeEnemy);
        }
    }

}
