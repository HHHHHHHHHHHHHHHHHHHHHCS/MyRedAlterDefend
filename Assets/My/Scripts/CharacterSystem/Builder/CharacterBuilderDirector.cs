using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterBuilderDirector 
{
    public static AbsCharacter Construct(AbsCharacterBuilder builder)
    {
        var attr = builder.AddCharacterAttr();
        var go = builder.AddGameObject(attr);
        var weapon = builder.AddWeapon();
        return builder.Character.OnInit(go, attr, weapon, builder.spawnPosition);
    }
}
