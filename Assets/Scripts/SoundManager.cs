using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // シングルトン
    // ゲーム内に1つしか存在しあに物(音を管理する物とか)
    // 利用場所：シーン間でのデータ共有・オブジェクト共有
    // 書き方
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
    // ------- シングルトン終わり---------------

    public AudioSource audioSournceBGM; // BGMのスピーカー
    public AudioClip[] audioClipsBGM;   // BGMの素材(0:Title, 1:Town, 2:Quest, 3:Battle)

    public AudioSource audioSourceSE;   // SEのスピーカー
    public AudioClip[] audioClipsSE;    // 鳴らす素材

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
