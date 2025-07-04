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
        DataManager.instance.NeedGuide = true;
        DataManager.instance.NeedHello = true;
        VoiceManager.instance.main.clip = null;
    }
    /// <summary>
    /// 开始落地灯引导
    /// </summary>
    public void CloseBegin()
    {
        GameManager.instance.DisableAll();
        MainMap.SetActive(true);
        Luodideng.SetActive(true);
        guides[0].SetActive(true);  
        Invoke("ShowGuide2",3);
        GameManager.instance.Init();
        gameObject.SetActive(false);
    }
    public void ShowGuide2()
    {
        guides[1].SetActive(true);
    }
}
