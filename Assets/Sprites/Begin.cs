using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : MonoBehaviour
{
    public GameObject MainMap;
    public GameObject Luodideng;
    public GameObject[] guides;
    public void CloseBegin()
    {
        //进行游戏初始化
        GameManager.instance.Init();
        GetComponent<SpriteRenderer>().DOFade(0, 1).OnComplete(() =>
        {
            MainMap.SetActive(true);
            Luodideng.SetActive(true);
            guides[0].SetActive(true);
            Invoke("ShowGuide2",3);
        }
        );
    }
    public void ShowGuide2()
    {
        guides[1].SetActive(true);
    }
}
