using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsWeapon
{
    protected int atk;
    protected int atkPlusValue;
    protected float atkRange;

    protected GameObject prefab;
    protected AbsCharacter owner;
    protected ParticleSystem particle;
    protected LineRenderer line;
    protected Light light;
    protected AudioSource audio;

    public abstract void Fire(Vector3 targetPosition);
}
