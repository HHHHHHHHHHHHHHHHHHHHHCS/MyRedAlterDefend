﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : AbsGameSystem
{
    private const float max_Energy = 100, recoverSecond = 5;

    private float nowEnergy;


    public override void OnInit()
    {
        nowEnergy = max_Energy;
        GameFacade.Instance.UpdateEnergySlider(nowEnergy, max_Energy);
    }

    public override void OnUpdate()
    {
        if (nowEnergy >= max_Energy)
        {
            return;
        }
        nowEnergy += recoverSecond * Time.deltaTime;
        nowEnergy = Mathf.Min(nowEnergy, max_Energy);
        GameFacade.Instance.UpdateEnergySlider(nowEnergy, max_Energy);
    }


    public bool UseEnergy(int value)
    {
        if (nowEnergy >= value)
        {
            nowEnergy -= value;
            GameFacade.Instance.UpdateEnergySlider(nowEnergy, max_Energy);
            return true;
        }
        return false;
    }

    public void RecycleEnergy(int value)
    {
        nowEnergy = Mathf.Clamp(nowEnergy + value, 0, max_Energy);
        GameFacade.Instance.UpdateEnergySlider(nowEnergy, max_Energy);
    }
}
