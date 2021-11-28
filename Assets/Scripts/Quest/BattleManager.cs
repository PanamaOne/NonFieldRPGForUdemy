using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// 対戦の管理
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

    // サンプルコルーチン
    //IEnumerator SampleCol()
    //{
    //    Debug.Log("コルーチン開始");
    //    yield return new WaitForSeconds(2f);
    //    Debug.Log("2秒経過");
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
        // PlayerがEnemyに攻撃
        SoundManager.instance.PlaySE(1);
        int damage = player.Attack(enemy);
        DialogTextManager.instance.SetScenarios(new string[] {
            "Playerの攻撃\nモンスターに" + damage + "ダメージを与えた。"
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
        // EnemyがPlayerに攻撃
        int damage = enemy.Attack(player);
        playerDamegePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        playerUI.UpdateUI(player);
        DialogTextManager.instance.SetScenarios(new string[] { 
            "モンスターの攻撃\nプレイヤーは" + damage + "ダメージを受けた。"
        });
        if(player.hp <= 0)
        {
            // Playerが死んだ場合の実装
            yield return new WaitForSeconds(2f);
            questManager.PlayerDeath();
        }
    }

    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(2f);
        DialogTextManager.instance.SetScenarios(new string[] {
            "モンスターは逃げて行った。"
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
