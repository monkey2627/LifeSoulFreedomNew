using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : MonoBehaviour
{
    public GameObject MainMap;
    public GameObject Luodideng;
    public GameObject[] guides;
    private void OnEnable()
    {
        
        VoiceManager.instance.main.clip = null;
     
    }
    public void CloseBegin()
    {
        //进行游戏初始化
        GameManager.instance.Init();
        
       
            MainMap.SetActive(true);
            Luodideng.SetActive(true);
            guides[0].SetActive(true);
           
            Invoke("ShowGuide2",3); gameObject.SetActive(false);
       
        
    }
    public void ShowGuide2()
    {
        guides[1].SetActive(true);
    }
}
