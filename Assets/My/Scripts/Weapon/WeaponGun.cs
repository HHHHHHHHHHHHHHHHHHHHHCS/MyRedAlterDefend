using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : AbsWeapon
{
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
