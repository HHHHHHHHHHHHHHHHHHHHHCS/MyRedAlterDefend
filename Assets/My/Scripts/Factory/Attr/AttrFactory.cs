using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttrFactory : IAttrFactory
{
    private Dictionary<Type, CharacterBaseAttr> characterBaseAttrDir;
    private Dictionary<WeaponType, WeaponBaseAttr> weaponBaseAttrDir;

    public AttrFactory()
    {
        OnInitCharacterDir();
        OnInitWeaponDir();
    }

    private void OnInitCharacterDir()
    {
        characterBaseAttrDir = new Dictionary<Type, CharacterBaseAttr>();
        characterBaseAttrDir.Add(typeof(SoldierAttrStrategy)
            , new CharacterBaseAttr("上尉士兵", "CaptainIcon", "Soldier1", 100, 3.5f));
        characterBaseAttrDir.Add(typeof(SoldierAttrStrategy)
            , new CharacterBaseAttr("中士士兵", "SergeantIcon", "Soldier3", 90, 3f));
        characterBaseAttrDir.Add(typeof(SoldierAttrStrategy)
            , new CharacterBaseAttr("新手士兵", "RookieIcon", "Soldier2", 80, 2.5f));
        characterBaseAttrDir.Add(typeof(SoldierAttrStrategy)
            , new CharacterBaseAttr("小精灵", "ElfIcon", "Enemy1", 100, 3f));
        characterBaseAttrDir.Add(typeof(SoldierAttrStrategy)
            , new CharacterBaseAttr("怪物", "OgreIcon", "Enemy2", 120, 4f));
        characterBaseAttrDir.Add(typeof(SoldierAttrStrategy)
            , new CharacterBaseAttr("巨魔", "TrollIcon", "Enemy3", 240, 1f));
    }
    private void OnInitWeaponDir()
    {
        weaponBaseAttrDir = new Dictionary<WeaponType, WeaponBaseAttr>();
        weaponBaseAttrDir.Add(WeaponType.Gun, new WeaponBaseAttr("WeaponGun", 20, 5, 0.5f));
        weaponBaseAttrDir.Add(WeaponType.Gun, new WeaponBaseAttr("WeaponRifle", 30, 7.5f, 1f));
        weaponBaseAttrDir.Add(WeaponType.Gun, new WeaponBaseAttr("WeaponRocket", 40, 10, 1.5f));
    }

    public CharacterBaseAttr GetCharacterBaseAttr(Type t)
    {
        CharacterBaseAttr attr = null;
        if (!characterBaseAttrDir.TryGetValue(t,out attr))
        {
            Debug.Log("无法得到 CharacterBase T 的基础属性");
            return null;
        }
        return attr;
    }

    public WeaponBaseAttr GetWeaponBaseAttr(WeaponType t)
    {
        WeaponBaseAttr attr = null;
        if (!weaponBaseAttrDir.TryGetValue(t, out attr))
        {
            Debug.Log("无法得到 WeaponType 的基础属性");
            return null;
        }
        return attr;
    }
}
