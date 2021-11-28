using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    public void OnToQuestButton()
    {
        SoundManager.instance.PlaySE(0);
    }

    // Start is called before the first frame update
    void Start()
    { 
        DialogTextManager.instance.SetScenarios(new string[] { "äXÇ…íÖÇ¢ÇΩÅB" });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
