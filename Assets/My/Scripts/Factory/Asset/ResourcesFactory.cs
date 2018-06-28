using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesFactory : IAssetFactory
{
    public const string SoldierPath = "Characters/Soldier/";
    public const string EnemyPath = "Characters/Enemy/";
    public const string WeaponPath = "Weapons/";
    public const string EffectPath = "Effects/";
    public const string AudiotPath = "Audios/";
    public const string SpritePath = "Sprites/";

    public AudioClip LoadAudioClip(string _name)
    {
        return LoadAsset<AudioClip>(AudiotPath + _name);
    }

    public GameObject LoadEffect(string _name)
    {
        return InstantiateGameObject(EffectPath + _name);
    }

    public GameObject LoadEnemy(string _name)
    {
        return InstantiateGameObject(EnemyPath + _name);
    }

    public GameObject LoadSoldier(string _name)
    {
        return InstantiateGameObject(SoldierPath + _name);
    }

    public Sprite LoadSprite(string _name)
    {
        return LoadAsset<Sprite>(SpritePath + _name);
    }

    public GameObject LoadWeapon(string _name)
    {
        return InstantiateGameObject(WeaponPath + _name);
    }

    public GameObject InstantiateGameObject(string _path)
    {
        GameObject go = Resources.Load<GameObject>(_path);
        if (go == null)
        {
            Debug.Log("InstantiateGameObject 无法加载资源，路径：" + _path);
            return null;
        }
        return UnityEngine.GameObject.Instantiate(go);
    }

    public T LoadAsset<T>(string _path) where T : UnityEngine.Object
    {
        T asset = Resources.Load<T>(_path);
        if (asset == null)
        {
            Debug.Log("LoadAsset 无法加载资源，路径：" + _path);
            return null;
        }
        return asset;
    }
}
