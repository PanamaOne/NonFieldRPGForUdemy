using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab;  // 生成するプレファブ(Unityエディタから設定する)

    int currentStage = 0;   // 現在のステージ進行度
    int[] encountTable = { -1, -1, 0, -1, 0, -1 };  // 敵に遭遇するテーブル：-1なら遭遇しない、0なら遭遇

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
    }

    // Nextボタンが押されたら
    public void OnNextButton()
    {
        currentStage++;
        stageUI.UpdateUI(currentStage);
        Debug.Log("進行度増加" + currentStage);

        if(encountTable.Length <= currentStage)
        {
            Debug.Log("クエストクリア");
            // クリア処理
        }
        else if(encountTable[currentStage] == 0)
        {
            EncountEnemy();
        }
    }

    void EncountEnemy()
    {
        stageUI.ShowButtons(false);
        Instantiate(enemyPrefab);
    }
}
