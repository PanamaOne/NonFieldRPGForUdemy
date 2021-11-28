using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // �V���O���g��
    // �Q�[������1�������݂����ɕ�(�����Ǘ����镨�Ƃ�)
    // ���p�ꏊ�F�V�[���Ԃł̃f�[�^���L�E�I�u�W�F�N�g���L
    // ������
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // ------- �V���O���g���I���---------------

    public AudioSource audioSournceBGM; // BGM�̃X�s�[�J�[
    public AudioClip[] audioClipsBGM;   // BGM�̑f��(0:Title, 1:Town, 2:Quest, 3:Battle)

    public AudioSource audioSourceSE;   // SE�̃X�s�[�J�[
    public AudioClip[] audioClipsSE;    // �炷�f��

    public void StopBGM()
    {
        audioSournceBGM.Stop();
    }

    public void PlayBGM(string sceneName)
    {
        audioSournceBGM.Stop();
        switch (sceneName)
        {
            default:
            case "Title":
                audioSournceBGM.clip = audioClipsBGM[0];
                break;
            case "Town":
                audioSournceBGM.clip = audioClipsBGM[1];
                break;
            case "Quest":
                audioSournceBGM.clip = audioClipsBGM[2];
                break;
            case "Battle":
                audioSournceBGM.clip = audioClipsBGM[3];
                break;
        }
        audioSournceBGM.Play();
    }

    public void PlaySE(int index)
    {
        audioSourceSE.PlayOneShot(audioClipsSE[index]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
