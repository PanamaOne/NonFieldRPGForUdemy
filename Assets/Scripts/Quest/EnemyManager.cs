using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // �o�^�֐�
    Action tapAction;       // �N���b�N���ꂽ���Ɏ��s�������֐�(�O��������s������)

    public new string name;
    public int hp;
    public int at;

    // �U������
    public void Attack(PlayerManager player)
    {
        player.Damage(at);
    }

    // �_���[�W���󂯂�
    public void Damage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
        }
    }

    // tapAction�Ɋ֐���o�^����֐������
    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }

    public void OnTap()
    {
        Debug.Log("�N���b�N���ꂽ");
        tapAction();
    }
}
