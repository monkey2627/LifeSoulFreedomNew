using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant : MonoBehaviour
{
    //��
    public GameObject lob;
    public GameObject dOption;
    public GameObject dDes;
    public GameObject dOptDes1;
    public GameObject dOptDes2;
    public GameObject dOptDes3;
    public GameObject dOptDes4;
    public void ClickD()
    {
        if (lob.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        VoiceManager.instance.ClickTiezhi();
        lob.GetComponent<Npc>().ClickTime += 1;
        lob.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            lob.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                lob.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    lob.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        dOption.SetActive(true);
        dDes.SetActive(true);
        dOptDes1.SetActive(false);
        dOptDes2.SetActive(false);
        dOptDes3.SetActive(false);
        dOptDes4.SetActive(false);
   
}
    /// <summary>
    /// �������ж��㣬ʹ��1��Ǯ�����2��ʳ
    /// </summary>
    public void Lobster1()
    {
        dDes.SetActive(false);
        dOptDes1.SetActive(true);
        GameManager.instance.AddLife(2);
        Bag.instance.UpdateBag();
        GetPopup.instance.ShowGets(31);
        GetPopup.instance.gameObject.SetActive(true);
        GetPopup.instance.work = false;
    }
    /// <summary>
    /// �������ж��㣬ʹ��һ�ž����1��Ǯ�����3��ʳ�����ܣ�25%���������
    /// </summary>
    public void Lobster2()
    {
        dDes.SetActive(false);
        dOptDes2.SetActive(true);
        GameManager.instance.AddLife(3);
            int t = Random.Range(1, 5);
            if (t == 2)
            {
                GameManager.instance.cards[(int)Card.Desire].number += 1;
            GetPopup.instance.ShowGets(28);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = false;
        }
        else
        {
            GetPopup.instance.ShowGets(27);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = false;
        }
        Bag.instance.UpdateBag();
    }
    /// <summary>
    /// �������ж��㣬ʹ��һ���������5��ʳ
    /// </summary>
    public void Lobster3()
    {
        dDes.SetActive(false);
        dOptDes3.SetActive(true);
        GameManager.instance.AddLife(5);
        GetPopup.instance.ShowGets(29);
        GetPopup.instance.gameObject.SetActive(true);
        GetPopup.instance.work = false;
        Bag.instance.UpdateBag();
        
    }
    /// <summary>
    /// �������ж��㣬ʹ��һ��������һ�ž�����5��ʳ�����ܣ�50%���������
    /// </summary>
    public void Lobster4()
    {

        dDes.SetActive(false);
        dOptDes4.SetActive(true);
        GameManager.instance.AddLife(3);
            int t = Random.Range(1, 3);
            if (t == 2)
            {
                GameManager.instance.cards[(int)Card.Luck].number += 1;
            GetPopup.instance.ShowGets(30);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = false;
        }
        else
        {
            GetPopup.instance.ShowGets(29);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = false;
        }
        Bag.instance.UpdateBag();

    }
    public void Back()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        gameObject.SetActive(false);
        MainMap.instance.gameObject.SetActive(true);
        Bag.instance.detect = false;
        lob.GetComponent<Npc>().CloseAll();

    }
    private void OnDisable()
    {
        Bag.instance.detect = false;
        lob.GetComponent<Npc>().CloseAll();
    }
}
