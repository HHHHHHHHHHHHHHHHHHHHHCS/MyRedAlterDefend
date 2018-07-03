using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Gun=0,
    Rifle,
    Rocket
}


public abstract class AbsWeapon
{
    protected WeaponBaseAttr weaponBaseAttr;
    protected int Atk { get { return weaponBaseAttr.Atk; } }
    public float AtkRange { get { return weaponBaseAttr.AtkRange; } }
    public float AtkTime { get { return weaponBaseAttr.AtkTime; } }

    protected float effectDisplayTime = 0;

    protected GameObject gameObject;
    protected AbsCharacter owner;
    protected ParticleSystem particle;
    protected LineRenderer line;
    protected Light light;
    protected AudioSource audio;

    public AbsWeapon(WeaponBaseAttr _weaponBaseAttr, GameObject _gameObject)
    {
        weaponBaseAttr = _weaponBaseAttr;
        gameObject = _gameObject;
        Transform effct = gameObject.transform.Find("Effect");
        particle = effct.GetComponent<ParticleSystem>();
        line = effct.GetComponent<LineRenderer>();
        light = effct.GetComponent<Light>();
        audio = effct.GetComponent<AudioSource>();
    }

    public void OnInit(AbsCharacter _charater)
    {
        owner = _charater;
        GameObject parent = UnityTool.FindChild(_charater.CharacterGameObject, "weapon-point");
        UnityTool.AttachGameObject(parent, gameObject);
    }


    public void OnUpdate()
    {
        if (effectDisplayTime > 0)
        {
            effectDisplayTime -= Time.deltaTime;
            if (effectDisplayTime <= 0)
            {
                DisableEffect();
            }
        }
    }

    public int AtkDamage(AbsCharacter character)
    {
        return Atk + character.CharacterAttr.CritValue;
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

    protected virtual void DoPlayBulletEffect(Vector3 targetPosition, float width)
    {

        line.enabled = true;
        line.startWidth = 0.05f; line.endWidth = 0.05f;
        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, targetPosition);
    }

    protected abstract void PlaySound();

    protected virtual void DoPlaySound(string audioName)
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
