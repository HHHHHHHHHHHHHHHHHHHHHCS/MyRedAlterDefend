using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameStateUI : AbsUIBase
{
    private GameObject[] heartArray;
    private GameObject gameOverBg;
    private Text soldierCountText;
    private Text nowLevelText;
    private Text engryText;
    private Button pauseButton;
    private Button backMenuButton;
    private Slider engrySlider;

    public override void OnInit()
    {
        PanelRoot = UITool.FindUIPanel("GameStateUI");

        heartArray = new GameObject[3];
        for(int i=0;i<heartArray.Length;i++)
        {
            FindUI(ref heartArray[i], "Hearts/Heart_" + (i +1));
        }

        FindUI(ref gameOverBg, "GameOverBg");
        FindUI(ref soldierCountText, "SoldierCountLabel/SoldierCountText");
        FindUI(ref nowLevelText, "NowLevelLabel/NowLevelText");
        FindUI(ref engryText, "EngrySlider/EngryText");
        FindUI(ref pauseButton, "PauseButton");
        FindUI(ref backMenuButton, "GameOverBg/BackMenuButton");
        FindUI(ref engrySlider, "EngrySlider");

    }
}
