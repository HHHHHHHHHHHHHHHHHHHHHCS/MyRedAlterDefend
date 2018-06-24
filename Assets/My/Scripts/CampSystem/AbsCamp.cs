using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsCamp
{
    protected GameObject gameObject;
    protected string name;
    protected string iconSprite;
    protected SoldierType soldierType;
    protected Vector3 position;
    protected float trainTime;
         

    public AbsCamp(GameObject _gameObject, string _name, string _iconSprite
        , SoldierType _soldierType, Vector3 _position, float _trainTime)
    {
        gameObject = _gameObject; ;
        name = _name;
        iconSprite = _iconSprite;
        soldierType = _soldierType;
        position = _position;
        trainTime = _trainTime;
    }

    public virtual void OnUpdate()
    {

    }
}
