using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponFactory
{
    AbsWeapon CreateWeapon(WeaponType _type);
}
