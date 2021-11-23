using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public Text hpText;
    public Text atText;

    public void SetupUI(PlayerManager player)
    {
        hpText.text = string.Format("HP : {0}", player.hp);
        atText.text = string.Format("AT : {0}", player.at);
    }

    public void UpdateUI(PlayerManager player)
    {
        hpText.text = string.Format("HP : {0}", player.hp);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
