using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySatateSystem
{
    private List<AbsEnemyState> statesList = new List<AbsEnemyState>();

    public AbsEnemyState CurrentSoldierState { get; private set; }

    public void AddStateRange(params AbsEnemyState[] states)
    {
        foreach (var item in states)
        {
            AddState(item);
        }
    }

    public void AddState(AbsEnemyState state)
    {
        if (state == null)
        {
            Debug.Log("AddState state 为空无法添加");
            return;
        }
        if (statesList.Contains(state))
        {
            Debug.Log("AddState " + state.StateID + " 已经存在，无法添加");
            return;
        }

        statesList.Add(state);
        if (statesList.Count == 1)
        {
            CurrentSoldierState = state;
        }
    }

    public void DeleteState(EnemyStateID id)
    {
        if (id == EnemyStateID.NullState)
        {
            Debug.Log("DeleteState 无法删除 NullState ");
            return;
        }

        for (int i = 0; i < statesList.Count; i++)
        {
            if (statesList[i].StateID == id)
            {
                statesList.RemoveAt(i);
                return;
            }
        }
        Debug.Log("DeleteState" + id + " 不存在 无法删除");
    }

    public void PerformnTransition(EnemyTransition trans)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.Log("PerformnTransition 无法执行 NullTransition ");
            return;
        }

        EnemyStateID id = CurrentSoldierState.GetIDByTransition(trans);
        if (id == EnemyStateID.NullState)
        {
            Debug.Log("PerformnTransition 无法执行 NullState ");
            return;
        }

        foreach (AbsEnemyState s in statesList)
        {
            if (s.StateID == id)
            {
                CurrentSoldierState.DoBeforeLeaving();
                CurrentSoldierState = s;
                CurrentSoldierState.DoBeforeEntering();
            }
        }
    }
}
