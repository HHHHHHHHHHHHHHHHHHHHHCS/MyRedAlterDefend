using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : AbsWeapon
{
    public WeaponRifle(int _atk, float _atkRange, float _atkTime, GameObject _gameObject) : base(_atk, _atkRange, _atkTime, _gameObject)
    {
    }

    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(targetPosition, 0.1f);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RifleShot");
    }

    protected override void SetDisplayTime()
    {
        effectDisplayTime = 0.3f;
    }
}
