using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : AbsEnemyState
{
    public EnemyChaseState(EnemySatateSystem _fsm, AbsCharacter _character) : base(_fsm, _character)
    {
        StateID = EnemyStateID.Chase;
    }

    public override void Act(List<AbsCharacter> targetList)
    {
        if (targetList != null && targetList.Count > 0)
        {
            character.MoveTo(targetList[0].Position);
        }
        else
        {
            character.MoveTo(GameFacade.Instance.GetEnemyTargetPosition());
        }
    }

    public override void Reason(List<AbsCharacter> targetList)
    {
        if (targetList != null && targetList.Count > 0)
        {
            Vector3 pos = targetList[0].Position;
            if (Vector3.Distance(character.Position,pos)<=character.Weapon.AtkRange)
            {
                fsm.PerformnTransition(EnemyTransition.CanAttack);
            }
        }
    }
}
