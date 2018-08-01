using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class E_ArchievementSystem 
{
    public static void LoadMemento(this GameFacade gameFacade)
    {
        ArchievementMemento archievementMemento = new ArchievementMemento();
        archievementMemento.LoadData();
        gameFacade.ArchievementSystem.SetMemento(archievementMemento);
    }

    public static void CreateMemento(this GameFacade gameFacade)
    {
        ArchievementMemento memento = gameFacade.ArchievementSystem.CreateMemento();
        memento.SaveData();
    }
}
