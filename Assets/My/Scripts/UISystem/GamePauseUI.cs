using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePauseUI : AbsUIBase
{
    private Text nowLevelText;
    private Button menuButton;
    private Button continueButton;

    public override void OnInit()
    {
        PanelRoot = UITool.FindUIPanel("GamePauseUI");

        FindUI(ref nowLevelText, "PausePanel/NowLevelLabel/NowLevelText");
        FindUI(ref menuButton, "PausePanel/MenuButton");
        FindUI(ref continueButton, "PausePanel/ContinueButton");
    }
}
