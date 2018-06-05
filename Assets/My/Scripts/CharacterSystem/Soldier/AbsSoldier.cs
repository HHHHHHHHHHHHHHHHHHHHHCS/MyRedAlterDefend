using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsSoldier : AbsCharacter
{
    protected SoldierSatateSystem fsmSystem;

    protected AbsSoldier() : base()
    {
        MakeFSM();
    }

    protected virtual void MakeFSM()
    {
        fsmSystem = new SoldierSatateSystem();

        SoldierIdleState idle = new SoldierIdleState(fsmSystem, this);
        idle.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);


        SoldierAttackState attack = new SoldierAttackState(fsmSystem, this);
        attack.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        attack.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

        SoldierChaseState chase = new SoldierChaseState(fsmSystem, this);
        chase.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        chase.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        fsmSystem.AddStateRange(idle, attack, chase);
    }

    public override void OnUpdateFSMAI(List<AbsCharacter> targetList) 
    {
        fsmSystem.CurrentSoldierState.Reason(targetList);
        fsmSystem.CurrentSoldierState.Act(targetList);
    }
}
