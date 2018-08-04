using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class E_CharacterSystem
{
    public static void RunCharacterVisiator(this GameFacade gameFacade,
        ICharacterVisiator characterVisiator)
    {
        gameFacade.CharacterSystem.RunVisitor(characterVisiator);
    }
}
