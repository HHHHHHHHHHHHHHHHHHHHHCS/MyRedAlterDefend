using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsCamp
{
    public GameObject GameObject;
    public string Name;
    public string IconSprite;
    public SoldierType SoldierType;
    public Vector3 Position;
    public float TrainTime;
         

    public AbsCamp(GameObject _gameObject, string _name, string _iconSprite
        , SoldierType _soldierType, Vector3 _position, float _trainTime)
    {
        GameObject = _gameObject; ;
        Name = _name;
        IconSprite = _iconSprite;
        SoldierType = _soldierType;
        Position = _position;
        TrainTime = _trainTime;
    }

    public virtual void OnUpdate()
    {

    }
}
