using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTransition
{
    NullTransition = 0,
    SeeSoldier,
    Attack,
}

public enum EnemyStateID 
{
    NullState,
    Chase,
    Attack,
}


public abstract class AbsEnemyState
{
    public EnemyStateID StateID { get; protected set; }

    protected Dictionary<EnemyTransition, EnemyStateID> map = new Dictionary<EnemyTransition, EnemyStateID>();
    protected AbsCharacter character;
    protected EnemySatateSystem fsm;

    public AbsEnemyState(EnemySatateSystem _fsm, AbsCharacter _character)
    {
        fsm = _fsm;
        character = _character;
    }


    public void AddTransition(EnemyTransition trans, EnemyStateID id)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.Log("EnemyState Error :trans 不能为空");
            return;
        }
        if (id == EnemyStateID.NullState)
        {
            Debug.Log("EnemyState Error :id 不能为空");
            return;
        }
        if (map.ContainsKey(trans))
        {
            Debug.Log("EnemyState Error :" + trans + "已经存在，不能添加");
        }
        map.Add(trans, id);
    }

    public void DeleteTransition(EnemyTransition trans, EnemyStateID id)
    {
        if (!map.ContainsKey(trans))
        {
            Debug.Log("EnemyState Error :" + trans + "不存在,无法删除");
            return;
        }
        map.Remove(trans);
    }

    public EnemyStateID GetIDByTransition(EnemyTransition trans)
    {
        EnemyStateID id = EnemyStateID.NullState;
        if (!map.TryGetValue(trans, out id))
        {
            Debug.Log("EnemyState Error :" + trans + "不存在,无法查找");
        }
        return id;
    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }

    public abstract void Reason(List<AbsCharacter> targetList);
    public abstract void Act(List<AbsCharacter> targetList);
}
