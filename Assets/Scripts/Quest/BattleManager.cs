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
        player.Attack(enemy);
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
        yield return new WaitForSeconds(1f);
        SoundManager.instance.PlaySE(1);
        // Enemy��Player�ɍU��
        enemy.Attack(player);
        playerDamegePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        playerUI.UpdateUI(player);
    }

    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(1f);

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
