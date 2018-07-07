using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameFacade
{
    private static GameFacade _instance;

    public static GameFacade Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameFacade();
            }
            return _instance;
        }
    }

    public ArchievementSystem ArchievementSystem { get; private set; }
    public CampSystem CampSystem { get; private set; }
    public CharacterSystem CharacterSystem { get; private set; }
    public EnergySystem EnergySystem { get; private set; }
    public GameEventSystem GameEventSystem { get; private set; }
    public StageSystem StageSystem { get; private set; }
    public UISystem UISystem { get; private set; }

    /// <summary>
    /// 内部单例化保护
    /// </summary>
    private GameFacade()
    {

    }

    public bool IsGameOver { get; set; }

    public GameFacade OnInit()
    {
        UISystem = new UISystem();
        ArchievementSystem = new ArchievementSystem();
        CampSystem = new CampSystem();
        CharacterSystem = new CharacterSystem();
        EnergySystem = new EnergySystem();
        GameEventSystem = new GameEventSystem();
        StageSystem = new StageSystem();


        UISystem.OnInit();
        ArchievementSystem.OnInit();
        CampSystem.OnInit();
        CharacterSystem.OnInit();
        EnergySystem.OnInit();
        GameEventSystem.OnInit();
        StageSystem.OnInit();

        return this;
    }

    public void OnRelease()
    {
        ArchievementSystem.OnRelease();
        CampSystem.OnRelease();
        CharacterSystem.OnRelease();
        EnergySystem.OnRelease();
        GameEventSystem.OnRelease();
        StageSystem.OnRelease();
        UISystem.OnRelease();
    }

    public void OnUpdate()
    {
        ArchievementSystem.OnUpdate();
        CampSystem.OnUpdate();
        CharacterSystem.OnUpdate();
        EnergySystem.OnUpdate();
        GameEventSystem.OnUpdate();
        StageSystem.OnUpdate();
        UISystem.OnUpdate();
    }

    public Vector3 GetEnemyTargetPosition()
    {
        return Vector3.zero;
    }
}
