﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : AbsWeapon
{
    public override void Fire(Vector3 targetPosition)
    {
        Debug.Log("播放攻击特效 WeaponRifle");

        Debug.Log("播放攻击声音 WeaponRifle");
    }
}