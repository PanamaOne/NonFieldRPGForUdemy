using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public new string name;
    public int hp;
    public int at;

    // 攻撃する
    public void Attack(PlayerManager player)
    {
        player.Damage(at);
    }

    // ダメージを受ける
    public void Damage(int damage)
    {
        hp -= damage;
        Debug.Log("EnemyのHPは" + hp);
    }

    public void OnTap()
    {
        Debug.Log("クリックされた");
    }
}
