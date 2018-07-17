using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Elf,
    Ogre,
    Troll
}

public abstract class AbsEnemy : AbsCharacter
{
    protected EnemySatateSystem fsmSystem;

    protected string attackEffectName;

    public AbsEnemy()
    {
        MakeFSM();
    }

    protected virtual void MakeFSM()
    {
        fsmSystem = new EnemySatateSystem();

        EnemyChaseState chase = new EnemyChaseState(fsmSystem,this);
        chase.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);
        fsmSystem.AddState(chase);

        EnemyAttackState attack = new EnemyAttackState(fsmSystem, this);
        attack.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);
        fsmSystem.AddState(attack);
    }


    public override void OnUpdateFSMAI(List<AbsCharacter> targetList)
    {
        fsmSystem.CurrentEnemyState.Reason(targetList);
        fsmSystem.CurrentEnemyState.Act(targetList);
    }

    public override void Attack(AbsCharacter target)
    {
        base.Attack(target);
        PlayAttackThing();
    }

    protected void PlayAttackThing()
    {
        DoPlayEffect(attackEffectName);
    }


}
