using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CampInfoUI : AbsUIBase
{
    private Text campText;
    private Text campLevelText;
    private Text weaponLevelText;
    private Text aliveUnitText;
    private Text trainningText;
    private Text trainTimeText;
    private Button upgradeCampButton;
    private Button upgradeWeaponButton;
    private Button trainButton;
    private Button cancelTrainButton;

    public override void OnInit()
    {
        PanelRoot = UITool.FindUIPanel("CampInfoUI");

        FindUI(ref campText, "CampIcon/CampText");
        FindUI(ref campLevelText, "CampLevelLabel/CampLevelText");
        FindUI(ref weaponLevelText, "WeaponLevelLabel/WeaponLevelText");
        FindUI(ref aliveUnitText, "AliveUnitLabel/AliveUnitText");
        FindUI(ref trainningText, "TrainningLabel/TrainningText");
        FindUI(ref trainTimeText, "TrainTimeLabel/TrainTimeText");
        FindUI(ref upgradeCampButton, "UpgradeCampButton");
        FindUI(ref upgradeWeaponButton, "UpgradeWeaponButton");
        FindUI(ref trainButton, "TrainButton");
        FindUI(ref cancelTrainButton, "CancelTrainButton");
    }
}
