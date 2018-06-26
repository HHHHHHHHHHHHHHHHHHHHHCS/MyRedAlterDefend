using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CampInfoUI : AbsUIBase
{
    private Image campSprite;
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
        FindUI(ref campSprite, "CampSprite");
        FindUI(ref campText, "CampSprite/CampText");
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

    public void ShowUIInfo(AbsCamp _camp)
    {
        OnShow();
        campSprite.sprite = FactoryManager.AssetFactory.LoadSprite(_camp.IconSprite);
        campText.text = _camp.Name;
        campLevelText.text = _camp.LV.ToString();
        ShowWeaponLevel(_camp.WeaponType);
    }

    public void ShowWeaponLevel(WeaponType _weaponType)
    {
        switch (_weaponType)
        {
            case WeaponType.Gun:
                weaponLevelText.text = "短枪";
                break;
            case WeaponType.Rifle:
                weaponLevelText.text = "长枪";
                break;
            case WeaponType.Rocket:
                weaponLevelText.text = "火箭";
                break;
            default:
                break;
        }
    }
}
