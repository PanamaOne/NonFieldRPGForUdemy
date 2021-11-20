using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ‘Îí‚ÌŠÇ—
public class BattleManager : MonoBehaviour
{
    public PlayerManager player;
    public EnemyManager enemy;

    // Start is called before the first frame update
    void Start()
    {
        // Player‚ªEnemy‚ÉUŒ‚
        player.Attack(enemy);
        // Enemy‚ªPlayer‚ÉUŒ‚
        enemy.Attack(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
