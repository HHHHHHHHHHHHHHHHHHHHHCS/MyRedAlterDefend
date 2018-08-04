using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameStateUI : AbsUIBase
{
    private const float showMsgTime = 2.5f;

    private GameObject[] heartArray;
    private GameObject gameOverBg;
    private Text soldierCountText;
    private Text enemyCountText;
    private Text nowLevelText;
    private Text eneryText;
    private Text tipText;
    private Button pauseButton;
    private Button backMenuButton;
    private Slider enerySlider;

    private float showMsgTimer = 0;
    private AliveCountVisiator aliveCountVisiator;

    public override void OnInit()
    {
        PanelRoot = UITool.FindUIPanel("GameStateUI");

        heartArray = new GameObject[3];
        for (int i = 0; i < heartArray.Length; i++)
        {
            FindUI(ref heartArray[i], "Hearts/Heart_" + (i + 1));
        }

        FindUI(ref gameOverBg, "GameOverBg");
        FindUI(ref soldierCountText, "SoldierCountLabel/SoldierCountText");
        FindUI(ref enemyCountText, "EnemyCountLabel/EnemyCountCount");
        FindUI(ref nowLevelText, "NowLevelLabel/NowLevelText");
        FindUI(ref eneryText, "EnerySlider/EneryText");
        FindUI(ref pauseButton, "PauseButton");
        FindUI(ref backMenuButton, "GameOverBg/BackMenuButton");
        FindUI(ref enerySlider, "EnerySlider");
        FindUI(ref tipText, "TipText");

        aliveCountVisiator = new AliveCountVisiator();
    }

    public override void OnUpdate()
    {
        if (showMsgTimer > 0)
        {
            showMsgTimer -= Time.deltaTime;
            if (showMsgTimer <= 0)
            {
                tipText.gameObject.SetActive(false);
            }
        }
    }

    public void ShowTipMsg(string _tip)
    {
        tipText.text = _tip;
        showMsgTimer = showMsgTime;
        tipText.gameObject.SetActive(true);
    }

    public void UpdateEnergySlider(float _nowEnergy, float _maxEnergy)
    {
        enerySlider.value = _nowEnergy / _maxEnergy;
        eneryText.text = string.Format("{0}/{1}", (int)_nowEnergy, (int)_maxEnergy);
    }

    public void UpdateAliveCount()
    {
        GameFacade.Instance.RunCharacterVisiator(aliveCountVisiator);
        soldierCountText.text = aliveCountVisiator.SoliderCount.ToString();
        enemyCountText.text = aliveCountVisiator.EnemyCount.ToString();
    }

    public void UpdateNowStage(int nowLv)
    {
        nowLevelText.text = nowLv.ToString();
    }
}
