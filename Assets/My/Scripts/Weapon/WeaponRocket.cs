using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRocket: AbsWeapon
{
    public override void Fire(Vector3 targetPosition)
    {
        Debug.Log("播放攻击特效 WeaponRocket");

        Debug.Log("播放攻击声音 WeaponRocket");
    }
}
