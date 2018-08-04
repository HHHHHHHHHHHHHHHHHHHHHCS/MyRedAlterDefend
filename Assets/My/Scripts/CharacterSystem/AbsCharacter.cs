using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class AbsCharacter
{
    protected const float waitDesotryTime = 2f;

    public CharacterAttr CharacterAttr { get; protected set; }

    public GameObject CharacterGameObject { get; protected set; }
    protected NavMeshAgent navMeshAgent;
    protected AudioSource audioSource;
    protected Animation anim;
    protected CapsuleCollider collider;
    public AbsWeapon Weapon { get; protected set; }

    public bool IsKilled { get; protected set; }
    public bool CanDesotry { get; protected set; }
    protected float waitDestoryTimer;

    public Vector3 Position
    {
        get
        {
            if (!CharacterGameObject)
            {
                Debug.Log("AbsCharacter GetPosition() gameObject为空");
                return Vector3.zero;
            }
            return CharacterGameObject.transform.position;
        }
    }

    public AbsCharacter OnInit(GameObject _gameObject, CharacterAttr _characterAttr, AbsWeapon _weapon,Vector3 _pos)
    {
        CharacterGameObject = _gameObject;
        CharacterGameObject.transform.position = _pos;
        CharacterAttr = _characterAttr;
        navMeshAgent = _gameObject.GetComponent<NavMeshAgent>();
        audioSource = _gameObject.GetComponent<AudioSource>();
        anim = _gameObject.GetComponentInChildren<Animation>();
        collider = _gameObject.GetComponent<CapsuleCollider>();
        Weapon = _weapon;
        Weapon.OnInit(this);
        return this;
    }

    public virtual void OnUpdate()
    {
        if(IsKilled)
        {
            waitDestoryTimer -= Time.deltaTime;
            if (waitDestoryTimer<=0)
            {
                CanDesotry = true;
            }
        }
        else
        {
            Weapon.OnUpdate();
        }

    }

    public abstract void RunVisitor(ICharacterVisiator visitor);

    public virtual void OnUpdateFSMAI(List<AbsCharacter> targetList)
    {

    }

    public void PlayAnim(string animName)
    {
        anim.Play(animName);
    }

    public virtual void Attack(AbsCharacter target)
    {
        if (Weapon != null)
        {
            Weapon.Fire(target.Position);
            CharacterGameObject.transform.LookAt(target.CharacterGameObject.transform);
            target.TakeDamage(Weapon.AtkDamage(this));
            PlayAnim("attack");
        }
    }

    public void MoveTo(Vector3 pos)
    {
        navMeshAgent.SetDestination(pos);
        PlayAnim("move");
    }

    public virtual int TakeDamage(int damage)
    {
        if(IsKilled)
        {
            return 0;
        }
        int endDamage = Mathf.Clamp(damage - CharacterAttr.DmgDescValue, 1, int.MaxValue);
        CharacterAttr.NowHp -= endDamage;
        if (CharacterAttr.NowHp <= 0)
        {
            CharacterAttr.NowHp = 0;
            Dead();
        }
        return CharacterAttr.NowHp;
    }

    public virtual void Dead()
    {
        OnKilled();
    }

    protected virtual void DoPlayEffect(string effectName)
    {
        if (string.IsNullOrEmpty(effectName))
        {
            return;
        }
        GameObject effect = FactoryManager.AssetFactory.LoadEffect(effectName);
        effect.AddComponent<AutoDestory>();
    }

    protected virtual void DoPlaySound(string soundName)
    {
        if (string.IsNullOrEmpty(soundName))
        {
            return;
        }
        AudioClip clip = FactoryManager.AssetFactory.LoadAudioClip(soundName);
        audioSource.PlayOneShot(clip);
    }

    public virtual void OnKilled()
    {
        IsKilled = true;
        navMeshAgent.isStopped = true;
        waitDestoryTimer = waitDesotryTime;
        anim.Stop();
        collider.enabled = false;
    }

    public virtual void OnRelease()
    {
        Object.Destroy(CharacterGameObject);

    }
}
