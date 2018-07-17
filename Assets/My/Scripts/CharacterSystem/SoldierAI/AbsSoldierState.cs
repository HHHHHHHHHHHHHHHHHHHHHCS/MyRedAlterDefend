using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoldierTransition
{
    NullTransition = 0,
    SeeEnemy,
    NoEnemy,
    CanAttack
}

public enum SoldierStateID
{
    NullState = 0,
    Idle,
    Chase,
    Attack,
}


public abstract class AbsSoldierState
{
    public SoldierStateID StateID { get; protected set; }

    protected Dictionary<SoldierTransition, SoldierStateID> map = new Dictionary<SoldierTransition, SoldierStateID>();
    protected AbsCharacter character;
    protected SoldierSatateSystem fsm;

    public AbsSoldierState(SoldierSatateSystem _fsm, AbsCharacter _character)
    {
        fsm = _fsm;
        character = _character;
    }


    public void AddTransition(SoldierTransition trans, SoldierStateID id)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.Log("SoldierState Error :trans 不能为空");
            return;
        }
        if (id == SoldierStateID.NullState)
        {
            Debug.Log("SoldierStateID Error :id 不能为空");
            return;
        }
        if (map.ContainsKey(trans))
        {
            Debug.Log("SoldierState Error :" + trans + "已经存在，不能添加");
        }
        map.Add(trans, id);
    }

    public void DeleteTransition(SoldierTransition trans, SoldierStateID id)
    {
        if (!map.ContainsKey(trans))
        {
            Debug.Log("SoldierState Error :" + trans + "不存在,无法删除");
            return;
        }
        map.Remove(trans);
    }

    public SoldierStateID GetIDByTransition(SoldierTransition trans)
    {
        SoldierStateID id = SoldierStateID.NullState;

        if (!map.TryGetValue(trans, out id))
        {
            Debug.Log("SoldierState StateID:"+ StateID+" Error :" + trans + "不存在,无法查找");
        }
        return id;
    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }

    public abstract void Reason(List<AbsCharacter> targetList);
    public abstract void Act(List<AbsCharacter> targetList);
}
