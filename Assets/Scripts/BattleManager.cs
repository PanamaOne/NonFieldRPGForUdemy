using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ΐ�̊Ǘ�
public class BattleManager : MonoBehaviour
{
    public PlayerManager player;
    public EnemyManager enemy;

    // Start is called before the first frame update
    void Start()
    {
        // Player��Enemy�ɍU��
        player.Attack(enemy);
        // Enemy��Player�ɍU��
        enemy.Attack(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
