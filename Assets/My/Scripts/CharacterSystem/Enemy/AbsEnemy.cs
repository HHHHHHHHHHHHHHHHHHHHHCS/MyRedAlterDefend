using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsEnemy : AbsCharacter
{
    protected EnemySatateSystem fsmSystem;

    public AbsEnemy()
    {
        MakeFSM();
    }

    protected virtual void MakeFSM()
    {
        fsmSystem = new EnemySatateSystem();
        EnemyChaseState chase = new EnemyChaseState(fsmSystem,this);
        fsmSystem.AddState(chase);

        EnemyAttackState attack = new EnemyAttackState(fsmSystem, this);
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
        PlayAttackEffect();
    }

    protected abstract void PlayAttackEffect();

    protected void DoPlayEffect(string effectName)
    {

    }
}
