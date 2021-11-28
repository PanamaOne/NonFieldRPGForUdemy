using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab;  // ��������v���t�@�u(Unity�G�f�B�^����ݒ肷��)
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;
    public GameObject questBG;

    int currentStage = 0;   // ���݂̃X�e�[�W�i�s�x
    int[] encountTable = { -1, -1, 0, -1, 0, -1 };  // �G�ɑ�������e�[�u���F-1�Ȃ瑘�����Ȃ��A0�Ȃ瑘��

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
        DialogTextManager.instance.SetScenarios(new string[] { "�X�ɒ������B" });
    }

    IEnumerator Searching()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "�T����..." });
        // �w�i��傫�����Ė߂�
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f)
            .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));
        // �t�F�[�h�A�E�g
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 2f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));

        // 2�b�ԏ�����ҋ@������
        yield return new WaitForSeconds(1f);

        currentStage++;
        stageUI.UpdateUI(currentStage);
        Debug.Log("�i�s�x����" + currentStage);

        if (encountTable.Length <= currentStage)
        {
            // �N���A����
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

    // Next�{�^���������ꂽ��
    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.ShowButtons(false);
        StartCoroutine(Searching());
    }

    void EncountEnemy()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "�����X�^�[�ɑ��������B" });
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
        DialogTextManager.instance.SetScenarios(new string[] { "�󔠂���ɓ��ꂽ�B\n�X�ɖ߂�܂��傤�B" });
        SoundManager.instance.StopBGM();
        // �N�G�X�g�N���A�ƕ\������
        // �X�ɖ߂�{�^���̂ݕ\������
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
