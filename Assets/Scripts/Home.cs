using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{

    public static Home instance;
    public GameObject clock;
    public GameObject canvas;
    public GameObject lightt;
    public GameObject[] tips;
    public int n = 0;
    //deng
    public void ClickLight()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
       lightt.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            lightt.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                lightt.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    lightt.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        clock.GetComponent<Npc>().CloseAll();
        canvas.GetComponent<Npc>().CloseAll();
        foreach (var item in tips)
        {
            item.SetActive(false);
        }
        tips[n++].SetActive(true);
        if (n == 15)
        {
            n = 0;
        }
    }
    //奔走的钟表
    public GameObject clockOpt;
    public GameObject ClockDes;
    public GameObject clockOpt1;
    private void Awake()
    {
        instance = this;
    }
    public void ClickClock()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (clock.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        clock.GetComponent<Npc>().ClickTime += 1;
        clock.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            clock.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                clock.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    clock.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        clockOpt1.SetActive(false);
        clockOpt.SetActive(true);
        ClockDes.SetActive(true);
        lightt.GetComponent<Npc>().CloseAll();
        canvas.GetComponent<Npc>().CloseAll();
    }
    /// <summary>
    /// 使用3张觉悟，此后5天，每日获得2张觉悟
    /// </summary>
    public void ClockOne()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        DataManager.instance.DoubleAwarenessDay = 5;
        ClockDes.SetActive(false);
        clockOpt1.SetActive(true);
        clockOpt.SetActive(false);
        Bag.instance.UpdateBag();
        clock.GetComponent<SpriteRenderer>().DOFade(0, 1f);
        clock.transform.DOLocalMove(new Vector3(-2.85f,1.6f,0), 1f).OnComplete(()=> { 
          GameManager.instance.SubWorkPoint();
          
        });
    }
    //空白画布  
    public GameObject canvasOpt;
    public GameObject canvasDes;
    public GameObject canvasOptDes;
    public GameObject canvasOptDes2;
    public GameObject canvasNotEmpty;
    public GameObject canvasNotEmptyDes;
    public GameObject canvasNotEmptyOpt;

    public void ClickCanvas()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (canvas.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        canvas.GetComponent<Npc>().ClickTime += 1;
        canvas.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            canvas.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                canvas.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    canvas.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        lightt.GetComponent<Npc>().CloseAll();
        canvasOptDes.SetActive(false);
        canvasOptDes2.SetActive(false);
        if (!DataManager.instance.GetMoney)
        { 
            canvasDes.SetActive(true); 
            canvasOpt.SetActive(true);
        }
        else
        {
            canvasNotEmptyDes.SetActive(true);
            canvasNotEmptyOpt.SetActive(true);

        }
        clock.GetComponent<Npc>().CloseAll();
    }
    /// <summary>
    /// 消耗一点行动点，获得一份故事
    /// </summary>
    public void Canvas1()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        GameManager.instance.cards[(int)Card.Story].number += 1;
        GetPopup.instance.work = true;
        GetPopup.instance.ShowGets(0);
        GetPopup.instance.gameObject.SetActive(true);
        Bag.instance.UpdateBag();
    }
    /// <summary>
    /// 消耗一点行动点，使用3张幸运、3张欲望、3张合作绘画，获得一张灵魂，
    /// 此后每日获得一份金钱
    /// </summary>
    public void Canvas2()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        GameManager.instance.cards[(int)Card.Soul].number += 1;
        DataManager.instance.GetMoney = true;
        canvasDes.SetActive(false);
        canvasOptDes2.SetActive(true);
        GetPopup.instance.ShowGets(16);
        GetPopup.instance.gameObject.SetActive(true);
        GetPopup.instance.work = true;
        canvasNotEmpty.SetActive(true);
        canvasNotEmptyOpt.SetActive(true);
        canvasOpt.SetActive(false);
        canvas.SetActive(false);
        Bag.instance.UpdateBag();

    }
    public void Back()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
       
        gameObject.SetActive(false);
        MainMap.instance.gameObject.SetActive(true); 
        VoiceManager.instance.CloseScence();
        Bag.instance.detect = false;
        clock.GetComponent<Npc>().CloseAll();
        canvas.GetComponent<Npc>().CloseAll();
    }
    private void OnDisable()
    {
        Bag.instance.detect = false;
        clock.GetComponent<Npc>().CloseAll();
        canvas.GetComponent<Npc>().CloseAll();
    }
}
