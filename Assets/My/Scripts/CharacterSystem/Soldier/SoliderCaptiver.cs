using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderCaptiver : AbsSoldier
{
    private AbsEnemy enemy;

    public SoliderCaptiver(AbsEnemy _enemy)
    {
        enemy = _enemy;
        CharacterAttr attr = new CharacterAttr(enemy.CharacterAttr.AttrStrategy,enemy.CharacterAttr.BaseAttr, 1);
        OnInit(enemy.CharacterGameObject, attr, enemy.Weapon, enemy.Position);
    }

    public override void DoPlayEffect(string effectName)
    {
        //enemy.DoPlayEffect(effectName);
    }

    public override void DoPlaySound(string soundName)
    {
        //enemy.DoPlaySound(soundName);
    }


}
