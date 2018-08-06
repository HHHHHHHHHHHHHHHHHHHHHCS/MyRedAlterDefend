using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoldierType
{
    Rookie,
    Sergeant,
    Captain,
    Captive,
}


public abstract class AbsSoldier : AbsCharacter
{
    protected SoldierSatateSystem fsmSystem;

    protected string deadEffectName;
    protected string deadSoundName;

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
        attack.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        SoldierChaseState chase = new SoldierChaseState(fsmSystem, this);
        chase.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        chase.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

        fsmSystem.AddStateRange(idle, attack, chase);
    }

    public override void RunVisitor(ICharacterVisiator visitor)
    {
        visitor.VisitorSoldier(this);
    }

    public override void OnUpdateFSMAI(List<AbsCharacter> targetList)
    {
        if (IsKilled)
        {
            return;
        }
        fsmSystem.CurrentSoldierState.Reason(targetList);
        fsmSystem.CurrentSoldierState.Act(targetList);
    }



    public override void OnKilled()
    {
        base.OnKilled();
        PlayDeadThing();
        GameFacade.Instance.TriggerEvent(GameEventType.SoldierKilled);
    }

    protected void PlayDeadThing()
    {
        DoPlayEffect(deadEffectName);
        DoPlaySound(deadSoundName);
    }


}
