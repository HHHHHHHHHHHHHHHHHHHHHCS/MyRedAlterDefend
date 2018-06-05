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
    protected Animation anim;

    public AbsWeapon Weapon { get; protected set; }

    public virtual void OnUpdate()
    {
        Weapon.OnUpdate();
    }

    public virtual void OnUpdateFSMAI(List<AbsCharacter> targetList)
    {

    }

    public Vector3 Position
    {
        get
        {
            if (!gameObject)
            {
                Debug.Log("AbsCharacter GetPosition() gameObject为空");
                return Vector3.zero;
            }
            return gameObject.transform.position;
        }
    }


    public void Attack(AbsCharacter target)
    {
        if (Weapon != null)
        {
            Weapon.Fire(target.Position);
        }
    }

    public void PlayAnim(string animName)
    {
        anim.Play(animName);
    }

    public void MoveTo(Vector3 pos)
    {
        navMeshAgent.SetDestination(pos);
    }


}
