using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public GameObject[] guides;
    public void ClickGuide2()
    {
        Invoke("ShowGuide4", 3);
    }
    void ShowGuide4()
    {
        guides[3].SetActive(true);
    }
    public void ClickGuide4()
    {
        Invoke("ShowGuide6", 3);
    }
    void ShowGuide6()
    {
        guides[5].SetActive(true);
    }
    public void ClickGuide6()
    {
        guides[5].SetActive(false);
        guides[4].SetActive(false);
        guides[6].SetActive(true);
        Invoke("ShowGuide8", 3);
    }
    void ShowGuide8()
    {
        guides[7].SetActive(true);
    }
    public void ClickGuide8()
    {
        guides[7].SetActive(false);
        guides[6].SetActive(false);
        guides[8].SetActive(true);
        Invoke("ShowGuide10", 3);
    }
    void ShowGuide10()
    {
        guides[9].SetActive(true);
    }
    public void ClickGuide10()
    {
        guides[9].SetActive(false);
        guides[8].SetActive(false);
        guides[10].SetActive(true);
        Invoke("ShowGuide12", 3);
    }
    public GameObject zhongbiao;
    void ShowGuide12()
    {
        zhongbiao.SetActive(true);
        guides[11].SetActive(true);
    }
    public GameObject Luodideng;
    public GameObject baoshi;
    public GameObject xingdongli1;
    public void ClickGuide12()
    {
        Luodideng.SetActive(false);
        Bag.instance.gameObject.SetActive(true);
        baoshi.SetActive(true);
        xingdongli1.SetActive(true);
    }
}

