using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttrFactory : IAttrFactory
{
    private Dictionary<Type, CharacterBaseAttr> characterBaseAttrDic;
    private Dictionary<WeaponType, WeaponBaseAttr> weaponBaseAttrDir;

    public AttrFactory()
    {
        OnInitCharacterDir();
        OnInitWeaponDir();
    }

    private void OnInitCharacterDir()
    {
        characterBaseAttrDic = new Dictionary<Type, CharacterBaseAttr>();
        characterBaseAttrDic.Add(typeof(SoldierCaptain)
            , new CharacterBaseAttr("上尉士兵", "CaptainIcon", "Soldier3", 100, 3.5f));
        characterBaseAttrDic.Add(typeof(SoldierSergeant)
            , new CharacterBaseAttr("中士士兵", "SergeantIcon", "Soldier2", 90, 3f));
        characterBaseAttrDic.Add(typeof(SoldierRookie)
            , new CharacterBaseAttr("新手士兵", "RookieIcon", "Soldier1", 80, 2.5f));
        characterBaseAttrDic.Add(typeof(EnemyElf)
            , new CharacterBaseAttr("小精灵", "ElfIcon", "Enemy1", 100, 3f, _critRate: 0.1f));
        characterBaseAttrDic.Add(typeof(EnemyOgre)
            , new CharacterBaseAttr("怪物", "OgreIcon", "Enemy2", 120, 4f, _critRate: 0.2f));
        characterBaseAttrDic.Add(typeof(EnemyTroll)
            , new CharacterBaseAttr("巨魔", "TrollIcon", "Enemy3", 240, 1f, _critRate: 0.3f));
    }
    private void OnInitWeaponDir()
    {
        weaponBaseAttrDir = new Dictionary<WeaponType, WeaponBaseAttr>();
        weaponBaseAttrDir.Add(WeaponType.Gun, new WeaponBaseAttr("WeaponGun", 20, 5, 0.5f));
        weaponBaseAttrDir.Add(WeaponType.Rifle, new WeaponBaseAttr("WeaponRifle", 30, 7.5f, 1f));
        weaponBaseAttrDir.Add(WeaponType.Rocket, new WeaponBaseAttr("WeaponRocket", 40, 10, 1.5f));
    }

    public CharacterBaseAttr GetCharacterBaseAttr(Type t)
    {
        CharacterBaseAttr attr = null;
        if (!characterBaseAttrDic.TryGetValue(t, out attr))
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
