using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoldierInfoUI : AbsUIBase
{
    private Text soldierNameText;
    private Text hPText;
    private Text labelText;
    private Text attackText;
    private Text attackRangeText;
    private Text speedText;
    private Slider hPSlider;

    public override void OnInit()
    {
        PanelRoot = UITool.FindUIPanel("SoldierInfoUI");

        FindUI(ref soldierNameText, "SoldierIcon/SoldierNameText");
        FindUI(ref hPText, "HPLabel/HPSlider/HPText");
        FindUI(ref labelText, "LvLabel/LabelText");
        FindUI(ref attackText, "AttackLabel/AttackText");
        FindUI(ref attackRangeText, "AttackRangeLabel/AttackRangeText");
        FindUI(ref speedText, "SpeedLabel/SpeedText");
        FindUI(ref hPSlider, "HPLabel/HPSlider");
    }
}
