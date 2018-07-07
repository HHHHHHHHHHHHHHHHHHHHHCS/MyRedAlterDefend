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
    private Text trainButtonText;
    private Button upgradeCampButton;
    private Button upgradeWeaponButton;
    private Button trainButton;
    private Button cancelTrainButton;

    private AbsCamp camp;

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
        FindUI(ref trainButtonText, "TrainButton/TrainButtonLabel/TrainButtonText");
        FindUI(ref upgradeCampButton, "UpgradeCampButton");
        FindUI(ref upgradeWeaponButton, "UpgradeWeaponButton");
        FindUI(ref trainButton, "TrainButton");
        FindUI(ref cancelTrainButton, "CancelTrainButton");

        trainButton.onClick.AddListener(OnClickTrainButton);
        cancelTrainButton.onClick.AddListener(OnClickCancelTrainButton);
        upgradeCampButton.onClick.AddListener(OnCampUpgradeClick);
        upgradeWeaponButton.onClick.AddListener(OnWeaponUpgradeClick);
        OnHide();
    }

    public void ShowUIInfo(AbsCamp _camp)
    {
        camp = _camp;
        AbsCamp.NowCampUI = this;
        OnShow();
        campSprite.sprite = FactoryManager.AssetFactory.LoadSprite(_camp.IconSprite);
        campText.text = _camp.Name;

        UpgradeCampInfo();
        UpdateInfo();
    }

    public void UpgradeCampInfo()
    {
        campLevelText.text = camp.LV.ToString();
        ShowWeaponLevel(camp.WeaponType);
        trainButtonText.text = camp.EnergyCostSoldierTrain.ToString()   ;
    }

    public void UpdateInfo()
    {
        trainningText.text = camp.TrainQueueCount.ToString();
        trainTimeText.text = camp.LastTrainTimer.ToString("f2");

        if (camp.TrainQueueCount == 0 && cancelTrainButton.interactable)
        {
            cancelTrainButton.interactable = false;
        }
        else if (camp.TrainQueueCount != 0 && !cancelTrainButton.interactable)
        {
            cancelTrainButton.interactable = true;
        }
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

    private void OnClickTrainButton()
    {
        if(camp.Train())
        {
            UpdateInfo();
        }
    }

    private void OnClickCancelTrainButton()
    {
        if (camp.CancelTrain())
        {
            UpdateInfo();
        }
    }

    private void OnCampUpgradeClick()
    {
        if(camp.UpgradeCamp())
        {
            UpgradeCampInfo();
        }

    }

    private void OnWeaponUpgradeClick()
    {
        if(camp.UpgradeWeapon())
        {
            UpgradeCampInfo();
        }
    }
}
