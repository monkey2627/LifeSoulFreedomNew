using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeArea : MonoBehaviour
{
    public GameObject dove;
    public GameObject cheng;
    //藏书鸽（封面是一只鸽子的书，常驻）：
    public GameObject doveDes;
    public GameObject doveOpt;
    public GameObject doveOptDes1;
    public GameObject doveOptDes2;
    public GameObject doveOptDes3;
    public void ClickD()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (dove.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        dove.GetComponent<Npc>().ClickTime += 1;
        cheng.GetComponent<Npc>().CloseAll();

        dove.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            dove.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                dove.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    dove.transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                });
            });

        });
        doveOptDes1.SetActive(false);
        doveOptDes2.SetActive(false);
        doveOptDes3.SetActive(false);
           doveDes.SetActive(true);
           doveOpt.SetActive(true);
    }
    ///消耗一点行动点，使用一张觉悟，获得信息，可能（25%）获得求知
    public void Dove1()
        {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        GameManager.instance.cards[(int)Card.Information].number += 1;
            int t = Random.Range(1, 5);
            if (t == 2)
            {
                GameManager.instance.cards[(int)Card.KnowledgeSeek].number += 1;
            GetPopup.instance.ShowGets(34);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        else
        {
            GetPopup.instance.ShowGets(8);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
            doveOptDes2.SetActive(false);
            doveOptDes3.SetActive(false);
            doveDes.SetActive(false);
            doveOptDes1.SetActive(true);
            Bag.instance.UpdateBag();

        }
    /// <summary>
    ///  消耗一点行动点，使用一张创造，获得5金钱或交易或幸运（34%，33%，33%）
    /// </summary>
    public void Dove2()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        int t = Random.Range(1, 4);
        if (t == 1)
        {
            GameManager.instance.cards[(int)Card.Money].number += 1; 
            GetPopup.instance.ShowGets(1);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;

        }
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Trade].number += 1;
            GetPopup.instance.ShowGets(7);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;

        }
        if (t == 3)
        {
            GameManager.instance.cards[(int)Card.Luck].number += 1;
            GetPopup.instance.ShowGets(13);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;

        }
        doveDes.SetActive(false);
        doveOptDes1.SetActive(false);
        doveOptDes3.SetActive(false);
        doveOptDes2.SetActive(true);
        Bag.instance.UpdateBag();

    }
    /// <summary>
    /// 消耗一点行动点，使用一份信息，获得2金钱
    /// </summary>
    public void Dove3()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        doveDes.SetActive(false);
        doveOptDes1.SetActive(false);
        doveOptDes2.SetActive(false);
        doveOptDes3.SetActive(true);
        GameManager.instance.cards[(int)Card.Money].number += 2;
        Bag.instance.UpdateBag();
        GetPopup.instance.ShowGets(24);
        GetPopup.instance.gameObject.SetActive(true);
        GetPopup.instance.work = true;

    }




    //公平的秤（常驻）

    public GameObject cDes;
    public GameObject cOpt;
    public GameObject cOptDes1;
    public GameObject cOptDes2;
    public GameObject cOptDes3;
    public GameObject cOptDes4;
    public void ClickC()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        dove.GetComponent<Npc>().CloseAll();
        if (cheng.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        cheng.GetComponent<Npc>().ClickTime += 1;
        cheng.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {
            cheng.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {
                cheng.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    cheng.transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                });
            });

        });
        cOptDes1.SetActive(false);
        cOptDes2.SetActive(false);
        cOptDes3.SetActive(false);
        cOptDes4.SetActive(false);
        cDes.SetActive(true);
        cOpt.SetActive(true);
    }
    /// <summary>
    /// 消耗一点行动点，使用一张觉悟和3金钱，获得造物，可能（25%）获得创造
    /// </summary>
    public void Cheng1()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        GameManager.instance.cards[(int)Card.Creation].number += 1;
        int t = Random.Range(1, 5);
        if (t == 2)
            {
                GameManager.instance.cards[(int)Card.Creativity].number += 1;
                GetPopup.instance.ShowGets(33);
                GetPopup.instance.gameObject.SetActive(true);
                GetPopup.instance.work = true;
        }
        else
        {
                GetPopup.instance.ShowGets(32);
                GetPopup.instance.gameObject.SetActive(true);
                GetPopup.instance.work = true;
        }
            cDes.SetActive(false);
            cOptDes1.SetActive(true);
        cOptDes2.SetActive(false);
        cOptDes3.SetActive(false);
        cOptDes4.SetActive(false);
        Bag.instance.UpdateBag();
            
          }
    /// <summary>
    /// 消耗一点行动点，使用12金钱，获得造物，获得合作/交易/欲望（34%/33%/33%）
    /// </summary>
    public void Cheng2()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;

        GameManager.instance.cards[(int)Card.Creation].number += 1;
       
           int t = Random.Range(1, 4);
            if (t == 1)
            {
                GameManager.instance.cards[(int)Card.Cooperation].number += 1;
                GetPopup.instance.ShowGets(21);
                GetPopup.instance.gameObject.SetActive(true);
                GetPopup.instance.work = true;
            }
            else if (t == 2)
            {
                GameManager.instance.cards[(int)Card.Trade].number += 1;
                GetPopup.instance.ShowGets(20);
                GetPopup.instance.gameObject.SetActive(true);
                GetPopup.instance.work = true;
            }
            else
            {
                GameManager.instance.cards[(int)Card.Desire].number += 1;
                GetPopup.instance.ShowGets(22);
                GetPopup.instance.gameObject.SetActive(true);
                GetPopup.instance.work = true;
            }
        
       
        cDes.SetActive(false);
        cOptDes1.SetActive(false);
        cOptDes4.SetActive(false);
        cOptDes3.SetActive(false);
        cOptDes2.SetActive(true);
        Bag.instance.UpdateBag();
    }/// <summary>
     /// 消耗一点行动点，使用一张觉悟和一张造物，获得4金钱，可能（25%）获得合作
     /// </summary>
    public void Cheng3()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        GameManager.instance.cards[(int)Card.Money].number += 4;
        int t = Random.Range(1, 5);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Cooperation].number += 1;
            GetPopup.instance.ShowGets(26);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        else
        {
            GetPopup.instance.ShowGets(25);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        Bag.instance.UpdateBag();      
        cDes.SetActive(false);
        cOptDes1.SetActive(false);
        cOptDes2.SetActive(false);
        cOptDes4.SetActive(false);
        cOptDes3.SetActive(true);
  
    }
    /// <summary>
    /// 消耗一点行动点，使用一张造物获得1金钱
    /// </summary>
    public void Cheng4()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        GameManager.instance.cards[(int)Card.Money].number += 1;
        Bag.instance.UpdateBag();
        cDes.SetActive(false);
        cOptDes1.SetActive(false);
        cOptDes2.SetActive(false);
        cOptDes3.SetActive(false);
        cOptDes4.SetActive(true);
        GetPopup.instance.ShowGets(23);
        GetPopup.instance.gameObject.SetActive(true);
        GetPopup.instance.work = true;

    }
    public void Back()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        gameObject.SetActive(false);
        MainMap.instance.gameObject.SetActive(true);
        VoiceManager.instance.CloseScence();
        dove.GetComponent<Npc>().CloseAll();
        cheng.GetComponent<Npc>().CloseAll();
        Bag.instance.detect = false;
    }
    private void OnDisable()
    {
      
        dove.GetComponent<Npc>().CloseAll();
        cheng.GetComponent<Npc>().CloseAll();
        Bag.instance.detect = false;
    }
}
