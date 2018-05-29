using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttr
{
    protected string chararcterName;
    protected string headSprite;
    protected int maxHP;
    protected float moveSpeed;
    protected int lv;
    protected int critRate;//暴击率0-1  敌人才有的

    protected IAttrStrategy attrStrategy;

    protected int nowHp;



}
