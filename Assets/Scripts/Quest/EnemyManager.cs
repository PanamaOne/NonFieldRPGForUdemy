using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : MonoBehaviour
{
    // �o�^�֐�
    Action tapAction;       // �N���b�N���ꂽ���Ɏ��s�������֐�(�O��������s������)

    public new string name;
    public int hp;
    public int at;
    public GameObject hitEffect;

    // �U������
    public int Attack(PlayerManager player)
    {
        return player.Damage(at);
    }

    // �_���[�W���󂯂�
    public int Damage(int damage)
    {
        Instantiate(hitEffect, this.transform, false);
        transform.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
        }
        return damage;
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
