using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab;  // ��������v���t�@�u(Unity�G�f�B�^����ݒ肷��)

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
            Debug.Log("�N�G�X�g�N���A");
            // �N���A����
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
