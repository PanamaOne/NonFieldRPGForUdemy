using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// StageUI(�X�e�[�W����UI/�i�s�{�^��/�X�ɖ߂�{�^��)�̊Ǘ�
public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public GameObject nextButton;
    public GameObject toTownButton;
    public GameObject stageClearText;

    public void UpdateUI(int currentStage)
    {
        stageText.text = string.Format("�X�e�[�W�F{0}", currentStage + 1);
    }

    public void ShowButtons(bool flag)
    {
        nextButton.SetActive(flag);
        toTownButton.SetActive(flag);
    }

    // Start is called before the first frame update
    void Start()
    {
        stageClearText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowClearText()
    {
        stageClearText.SetActive(true);
        nextButton.SetActive(false);
        toTownButton.SetActive(true);
    }
}