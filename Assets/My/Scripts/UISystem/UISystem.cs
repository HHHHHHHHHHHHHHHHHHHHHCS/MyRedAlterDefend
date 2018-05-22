using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : AbsGameSystem
{
    public CampUI CampUI { get; private set; }
    public GamePauseUI GamePauseUI { get; private set; }
    public GameStateInfoUI GameStateInfoUI { get; private set; }
    public SoliderInfoUI SoliderInfoUI { get; private set; }


    public override void OnInit()
    {
        CampUI = new CampUI();
        GamePauseUI = new GamePauseUI();
        GameStateInfoUI = new GameStateInfoUI();
        SoliderInfoUI = new SoliderInfoUI();

        CampUI.OnInit();
        GamePauseUI.OnInit();
        GameStateInfoUI.OnInit();
        SoliderInfoUI.OnInit();
    }

    public override void OnUpdate()
    {
        CampUI.OnUpdate();
        GamePauseUI.OnUpdate();
        GameStateInfoUI.OnUpdate();
        SoliderInfoUI.OnUpdate();
    }

    public override void OnRelease()
    {
        CampUI.OnRelease();
        GamePauseUI.OnRelease();
        GameStateInfoUI.OnRelease();
        SoliderInfoUI.OnRelease();
    }
}
