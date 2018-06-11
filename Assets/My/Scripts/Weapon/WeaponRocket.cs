using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRocket: AbsWeapon
{
    public WeaponRocket(int _atk, float _atkRange, float _atkTime, GameObject _gameObject) : base(_atk, _atkRange, _atkTime, _gameObject)
    {
    }

    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(targetPosition, 0.3f);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RocketShot");
    }

    protected override void SetDisplayTime()
    {
        effectDisplayTime = 0.4f;
    }
}
