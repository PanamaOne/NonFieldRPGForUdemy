using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// �ΐ�̊Ǘ�
public class BattleManager : MonoBehaviour
{
    public QuestManager questManager;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    EnemyManager enemy;
    public Transform playerDamegePanel;

    private void Start()
    {
        enemyUI.gameObject.SetActive(false);
        //StartCoroutine(SampleCol());
        playerUI.SetupUI(player);
    }

    // �T���v���R���[�`��
    //IEnumerator SampleCol()
    //{
    //    Debug.Log("�R���[�`���J�n");
    //    yield return new WaitForSeconds(2f);
    //    Debug.Log("2�b�o��");
    //}

    public void Setup(EnemyManager enemyManager)
    {
        SoundManager.instance.PlayBGM("Battle");
        enemyUI.gameObject.SetActive(true);
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);

        enemy.AddEventListenerOnTap(PlayerAttack);

        //enemy.transform.DOMove(new Vector3(0,10,0), 5f);
    }

    void PlayerAttack()
    {
        StopAllCoroutines();
        // Player��Enemy�ɍU��
        SoundManager.instance.PlaySE(1);
        int damage = player.Attack(enemy);
        DialogTextManager.instance.SetScenarios(new string[] {
            "Player�̍U��\n�����X�^�[��" + damage + "�_���[�W��^�����B"
        });
        enemyUI.UpdateUI(enemy);
        if(enemy.hp <= 0)
        {
            StartCoroutine(EndBattle());
        }
        else
        {
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.instance.PlaySE(1);
        // Enemy��Player�ɍU��
        int damage = enemy.Attack(player);
        playerDamegePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        playerUI.UpdateUI(player);
        DialogTextManager.instance.SetScenarios(new string[] { 
            "�����X�^�[�̍U��\n�v���C���[��" + damage + "�_���[�W���󂯂��B"
        });
        if(player.hp <= 0)
        {
            // Player�����񂾏ꍇ�̎���
            yield return new WaitForSeconds(2f);
            questManager.PlayerDeath();
        }
    }

    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(2f);
        DialogTextManager.instance.SetScenarios(new string[] {
            "�����X�^�[�͓����čs�����B"
        });
        Destroy(enemy.gameObject);
        enemyUI.gameObject.SetActive(false);
        SoundManager.instance.PlayBGM("Quest");
        questManager.EndBattle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
