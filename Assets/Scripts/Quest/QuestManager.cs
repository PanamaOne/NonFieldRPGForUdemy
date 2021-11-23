using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab;  // ��������v���t�@�u(Unity�G�f�B�^����ݒ肷��)
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;

    int currentStage = 0;   // ���݂̃X�e�[�W�i�s�x
    int[] encountTable = { -1, -1, 0, -1, 0, -1 };  // �G�ɑ�������e�[�u���F-1�Ȃ瑘�����Ȃ��A0�Ȃ瑘��

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
    }

    // Next�{�^���������ꂽ��
    public void OnNextButton()
    {
        currentStage++;
        stageUI.UpdateUI(currentStage);
        Debug.Log("�i�s�x����" + currentStage);

        if(encountTable.Length <= currentStage)
        {
            // �N���A����
            QuestClear();
        }
        else if(encountTable[currentStage] == 0)
        {
            EncountEnemy();
        }
    }

    void EncountEnemy()
    {
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
        // �N�G�X�g�N���A�ƕ\������
        // �X�ɖ߂�{�^���̂ݕ\������
        stageUI.ShowClearText();
        //sceneTransitionManager.LoadTo("Town");
    }
}
