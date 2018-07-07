using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class E_EnergySystem
{
    public static bool UseEnergy(this GameFacade facade, int value)
    {
        return facade.EnergySystem.UseEnergy(value);
    }

    public static void RecycleEnergy(this GameFacade facade, int value)
    {
        facade.EnergySystem.RecycleEnergy(value);
    }
}
