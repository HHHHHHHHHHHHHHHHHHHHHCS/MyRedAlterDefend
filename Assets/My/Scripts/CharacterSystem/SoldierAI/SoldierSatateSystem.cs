using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSatateSystem
{
    private List<AbsSoldierState> statesList = new List<AbsSoldierState>();

    public AbsSoldierState CurrentSoldierState { get; private set; }

    public void AddStateRange(params AbsSoldierState[] states)
    {
        foreach (var item in states)
        {
            AddState(item);
        }
    }

    public void AddState(AbsSoldierState state)
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

    public void DeleteState(SoldierStateID id)
    {
        if (id == SoldierStateID.NullState)
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

    public void PerformnTransition(SoldierTransition trans)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.Log("PerformnTransition 无法执行 NullTransition ");
            return;
        }

        SoldierStateID id = CurrentSoldierState.GetIDByTransition(trans);
        if (id == SoldierStateID.NullState)
        {
            Debug.Log("PerformnTransition 无法执行 NullState ");
            return;
        }

        foreach (AbsSoldierState s in statesList)
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
