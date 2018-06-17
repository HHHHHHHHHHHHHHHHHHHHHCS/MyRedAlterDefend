using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : AbsWeapon
{
    public WeaponRifle(WeaponBaseAttr _attr, GameObject _gameObject) : base(_attr, _gameObject)
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
