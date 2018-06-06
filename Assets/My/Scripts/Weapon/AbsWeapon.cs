using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsWeapon
{
    protected int atk;
    public float AtkRange { get; protected set; }
    public float AtkTime { get; protected set; }

    protected float effectDisplayTime = 0;

    protected GameObject prefab;
    protected AbsCharacter owner;
    protected ParticleSystem particle;
    protected LineRenderer line;
    protected Light light;
    protected AudioSource audio;


    public void OnUpdate()
    {
        if(effectDisplayTime>0)
        {
            effectDisplayTime -= Time.deltaTime;
            if(effectDisplayTime<=0)
            {
                DisableEffect();
            }
        }
    }


    public int AtkDamage(AbsCharacter character )
    {

        return atk + character.characterAttr.CritValue;
    }

    public virtual void Fire(Vector3 targetPosition)
    {
        PlayMuzzleEffect();
        PlayBulletEffect(targetPosition);
        PlaySound();
        SetDisplayTime();
    }

    protected virtual void PlayMuzzleEffect()
    {
        PlayMuzzleEffect();
    }

    protected virtual void DoPlayMuzzleEffect()
    {
        particle.Stop();
        particle.Play();
        light.enabled = true;
    }

    protected abstract void PlayBulletEffect(Vector3 targetPosition);

    protected virtual void DoPlayBulletEffect(Vector3 targetPosition,float width )
    {

        line.enabled = true;
        line.startWidth = 0.05f; line.endWidth = 0.05f;
        line.SetPosition(0, prefab.transform.position);
        line.SetPosition(1, targetPosition);
    }

    protected abstract void PlaySound();

    protected virtual void DoPlaySound(string audioName )
    {
        string clipName = audioName;
        AudioClip clip = null;
        audio.clip = clip;
        audio.Play();
    }

    protected abstract void SetDisplayTime();

    protected virtual void DisableEffect()
    {
        line.enabled = false;
        light.enabled = false;
    }
}
