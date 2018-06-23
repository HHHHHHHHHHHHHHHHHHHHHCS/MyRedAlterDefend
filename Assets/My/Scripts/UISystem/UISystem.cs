using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : AbsGameSystem
{
    public CampInfoUI CampInfoUI { get; private set; }
    public GamePauseUI GamePauseUI { get; private set; }
    public GameStateUI GameStateUI { get; private set; }
    public SoldierInfoUI SoliderInfoUI { get; private set; }


    public override void OnInit()
    {
        CampInfoUI = new CampInfoUI();
        GamePauseUI = new GamePauseUI();
        GameStateUI = new GameStateUI();
        SoliderInfoUI = new SoldierInfoUI();

        CampInfoUI.OnInit();
        GamePauseUI.OnInit();
        GameStateUI.OnInit();
        SoliderInfoUI.OnInit();
    }

    public override void OnUpdate()
    {
        CampInfoUI.OnUpdate();
        GamePauseUI.OnUpdate();
        GameStateUI.OnUpdate();
        SoliderInfoUI.OnUpdate();
    }

    public override void OnRelease()
    {
        CampInfoUI.OnRelease();
        GamePauseUI.OnRelease();
        GameStateUI.OnRelease();
        SoliderInfoUI.OnRelease();
    }
}
