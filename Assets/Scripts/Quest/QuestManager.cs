using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab;  // 生成するプレファブ(Unityエディタから設定する)
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;
    public GameObject questBG;

    int currentStage = 0;   // 現在のステージ進行度
    int[] encountTable = { -1, -1, 0, -1, 0, -1 };  // 敵に遭遇するテーブル：-1なら遭遇しない、0なら遭遇

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
        DialogTextManager.instance.SetScenarios(new string[] { "森に着いた。" });
    }

    IEnumerator Searching()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "探索中..." });
        // 背景を大きくして戻る
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f)
            .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));
        // フェードアウト
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 2f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));

        // 2秒間処理を待機させる
        yield return new WaitForSeconds(1f);

        currentStage++;
        stageUI.UpdateUI(currentStage);
        Debug.Log("進行度増加" + currentStage);

        if (encountTable.Length <= currentStage)
        {
            // クリア処理
            QuestClear();
        }
        else if (encountTable[currentStage] == 0)
        {
            EncountEnemy();
        }
        else
        {
            stageUI.ShowButtons(true);
        }
    }

    // Nextボタンが押されたら
    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.ShowButtons(false);
        StartCoroutine(Searching());
    }

    void EncountEnemy()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "モンスターに遭遇した。" });
        stageUI.ShowButtons(false);
        GameObject enemyObj = Instantiate(enemyPrefab);
        EnemyManager enemyManager = enemyObj.GetComponent<EnemyManager>();
        battleManager.Setup(enemyManager);
    }

    public void EndBattle()
    {
        stageUI.ShowButtons(true);
    }

    void QuestClear()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "宝箱を手に入れた。\n街に戻りましょう。" });
        SoundManager.instance.StopBGM();
        // クエストクリアと表示する
        // 街に戻るボタンのみ表示する
        stageUI.ShowClearText();
        //sceneTransitionManager.LoadTo("Town");
        SoundManager.instance.PlaySE(2);
    }

    public void OnToTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }

    public void PlayerDeath()
    {
        sceneTransitionManager.LoadTo("Town");
    }
}
