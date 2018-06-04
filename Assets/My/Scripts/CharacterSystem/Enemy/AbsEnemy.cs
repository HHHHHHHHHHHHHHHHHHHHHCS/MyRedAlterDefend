using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsEnemy : AbsCharacter
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


    public void UpdateFSMAI(List<AbsCharacter> targetList)
    {
        fsmSystem.CurrentEnemyState.Reason(targetList);
        fsmSystem.CurrentEnemyState.Act(targetList);
    }
}
