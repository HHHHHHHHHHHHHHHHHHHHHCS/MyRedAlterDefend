﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRocket : AbsWeapon
{
    public WeaponRocket(WeaponBaseAttr _attr, GameObject _gameObject) : base(_attr, _gameObject)
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
