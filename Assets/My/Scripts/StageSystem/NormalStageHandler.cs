using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStageHandler : IStageHandler
{
    private EnemyType enemyType;
    private WeaponType weaponType;
    private int count;
    private Vector3 position;

    public NormalStageHandler(int _lv, EnemyType _enemyType, WeaponType _weaponType
        , int _count, Vector3 _position, int _countToFinish)
        :base (_lv,_countToFinish)
    {
        enemyType = _enemyType;
        weaponType = _weaponType;
        count = _count;
        position = _position;
    }

    protected override void UpdateStage()
    {
        base.UpdateStage();
    }

    public bool CheckIsFinised()
    {
        return GameFacade.Instance.StageSystem.GetCountOfEnemyKilled() >= countToFinish;
    }
}
