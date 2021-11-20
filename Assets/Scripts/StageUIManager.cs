using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// StageUI(ステージ数のUI/進行ボタン/街に戻るボタン)の管理
public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public GameObject nextButton;
    public GameObject toTownButton;

    public void UpdateUI(int currentStage)
    {
        stageText.text = string.Format("ステージ：{0}", currentStage + 1);
    }

    public void ShowButtons(bool flag)
    {
        nextButton.SetActive(flag);
        toTownButton.SetActive(flag);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
