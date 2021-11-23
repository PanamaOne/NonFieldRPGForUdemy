using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ΐ�̊Ǘ�
public class BattleManager : MonoBehaviour
{
    public QuestManager questManager;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    EnemyManager enemy;

    private void Start()
    {
        enemyUI.gameObject.SetActive(false);   
    }

    public void Setup(EnemyManager enemyManager)
    {
        enemyUI.gameObject.SetActive(true);
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);

        enemy.AddEventListenerOnTap(PlayerAttack);
    }

    void PlayerAttack()
    {
        // Player��Enemy�ɍU��
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
        if(enemy.hp <= 0)
        {
            Destroy(enemy.gameObject);
            enemyUI.gameObject.SetActive(false);
            EndBattle();
        }
        else
        {
            EnemyTurn();
        }
    }

    void EnemyTurn()
    {
        // Enemy��Player�ɍU��
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }

    void EndBattle()
    {
        questManager.EndBattle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
