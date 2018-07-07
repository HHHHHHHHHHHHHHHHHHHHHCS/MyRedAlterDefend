using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class E_UISystem
{
    public static void ShowTipMessage(this GameFacade facade, string msg)
    {
        facade.UISystem.GameStateUI.ShowTipMsg(msg);
    }

    public static void UpdateEnergySlider(this GameFacade facade, float _nowEnergy, float _maxEnergy)
    {
        facade.UISystem.GameStateUI.UpdateEnergySlider(_nowEnergy, _maxEnergy);
    }
}
