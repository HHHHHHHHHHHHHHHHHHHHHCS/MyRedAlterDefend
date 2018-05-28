using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AbsCharacter
{
    protected CharacterAttr characterAttr;

    protected GameObject gameObject;
    protected NavMeshAgent navMeshAgent;
    protected AudioSource audioSource;

    protected AbsWeapon weapon;


    public void Attack(Vector3 targetPosition)
    {
        if(weapon != null)
        {
            weapon.Fire(targetPosition);
        }

    }
}
