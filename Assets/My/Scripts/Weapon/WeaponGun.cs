using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : AbsWeapon
{
    public WeaponGun(int _atk, float _atkRange, float _atkTime, GameObject _gameObject) : base(_atk, _atkRange, _atkTime, _gameObject)
    {
    }

    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(targetPosition, 0.05f);
    }

    protected override void PlaySound()
    {
        DoPlaySound("GunShot");
    }

    protected override void SetDisplayTime()
    {
        effectDisplayTime = 0.2f;
    }
}
