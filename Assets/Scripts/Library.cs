using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{

    public GameObject pen;
    public GameObject book;
    public GameObject ink;
    public GameObject dangangui;

    //��૵���ҳ
    public GameObject bookOption;
    public GameObject bookDes;
    public GameObject bookOptDes1;
    public GameObject bookOptDes2;
    public GameObject bookOptDes3;
    public void ClickBook()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (book.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        book.GetComponent<Npc>().ClickTime += 1;
        book.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            book.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                book.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    book.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        bookOptDes1.SetActive(false);
        bookOptDes2.SetActive(false);
        bookOptDes3.SetActive(false);
        bookOption.SetActive(true);
        bookDes.SetActive(true);
        pen.GetComponent<Npc>().CloseAll();
        ink.GetComponent<Npc>().CloseAll();
        dangangui.GetComponent<Npc>().CloseAll();
    }
    /// <summary>
    /// ����һ���ж��㣬����2��Ǯ���һ��֪ʶ
    /// </summary>
    public void Book1()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        GameManager.instance.cards[(int)Card.Knowledge].number += 1;
        bookDes.SetActive(false);
        bookOptDes2.SetActive(false);
        bookOptDes3.SetActive(false);
        bookOptDes1.SetActive(true);
        Bag.instance.UpdateBag();
        GetPopup.instance.ShowGets(4);
        GetPopup.instance.gameObject.SetActive(true);
        GetPopup.instance.work = true;

    }
    /// <summary>
    /// ����һ���ж��㣬����2��Ǯ��һ�ž�����һ��֪ʶ�����ܣ�25%�������֪
    /// </summary>
    public void Book2()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;

        GameManager.instance.cards[(int)Card.Knowledge].number += 1;
            int t = Random.Range(1, 5);
            if(t == 2)
        {
              GameManager.instance.cards[(int)Card.KnowledgeSeek].number += 1;
            GetPopup.instance.ShowGets(36);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        else
        {
            GetPopup.instance.ShowGets(4);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        Debug.Log(GameManager.instance.cards[(int)Card.Knowledge].number);
        bookOptDes1.SetActive(false);
        bookOptDes3.SetActive(false);
        bookDes.SetActive(false);
        bookOptDes2.SetActive(true);
        Bag.instance.UpdateBag();
    }
    /// <summary>
    /// ����һ���ж��㣬��3��īˮ��ȡһ����Ϣ/��֪/���ˣ�10%/10%/80%����
    /// </summary>
    public void Book3()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        int t = Random.Range(1, 11);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Information].number += 1;
            GetPopup.instance.ShowGets(8);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        else if (t == 3)
        {
            GameManager.instance.cards[(int)Card.KnowledgeSeek].number += 1;
            GetPopup.instance.ShowGets(5);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        else 
        {
            GameManager.instance.cards[(int)Card.Luck].number += 1;
            GetPopup.instance.ShowGets(13);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        bookDes.SetActive(false);
        bookOptDes1.SetActive(false);
        bookOptDes2.SetActive(false);
        bookOptDes3.SetActive(true);
        Bag.instance.UpdateBag();
    }
    //������īˮƿ
    public GameObject inkOption;
    public GameObject inkDes;
    public GameObject inkOptDes1;
    public GameObject inkOptDes2;
    public GameObject inkOptDes3;
    public void ClickInk()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (ink.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        ink.GetComponent<Npc>().ClickTime += 1;
        ink.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            ink.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                ink.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    ink.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        inkOptDes1.SetActive(false);
        inkOptDes2.SetActive(false);
        inkOptDes3.SetActive(false);
        inkOption.SetActive(true);
        inkDes.SetActive(true);
        pen.GetComponent<Npc>().CloseAll();
        book.GetComponent<Npc>().CloseAll();
        dangangui.GetComponent<Npc>().CloseAll();
    }
    /// <summary>
    /// ����һ���ж��㣬��2��֪ʶ��ȡ������֪
    /// </summary>
    public void Ink1()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        GameManager.instance.cards[(int)Card.KnowledgeSeek].number += 1;
        inkDes.SetActive(false);
        inkOptDes2.SetActive(false);
        inkOptDes3.SetActive(false);
        inkOptDes1.SetActive(true);
        Bag.instance.UpdateBag();
        GetPopup.instance.ShowGets(5);
        GetPopup.instance.gameObject.SetActive(true);
        GetPopup.instance.work = true;
    }
    /// <summary>
    /// ����һ���ж��㣬���ܣ�25%�����īˮ
    /// </summary>
    public void Ink2()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        inkDes.SetActive(false);
        inkOptDes1.SetActive(false);
        inkOptDes3.SetActive(false);
        inkOptDes2.SetActive(true);
        int t = Random.Range(1, 5);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Ink].number += 1;
            GetPopup.instance.ShowGets(11);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
            Bag.instance.UpdateBag();
            return;
        }
        else
        {
            GameManager.instance.SubWorkPoint();
        }
        Bag.instance.UpdateBag();
    }
    /// <summary>
    /// ����һ���ж��㣬ʹ��һ�ź�������ô���/��֪��50%/50%��
    /// </summary>
    public void Ink3()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        inkDes.SetActive(false);
        inkOptDes1.SetActive(false);
        inkOptDes2.SetActive(false);
        inkOptDes3.SetActive(true);
        int t = Random.Range(1, 3);
            if (t == 2)
            {
                GameManager.instance.cards[(int)Card.Creativity].number += 1;
            GetPopup.instance.ShowGets(9);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;

        }
            else
            {
                GameManager.instance.cards[(int)Card.KnowledgeSeek].number += 1;
            GetPopup.instance.ShowGets(5);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        Bag.instance.UpdateBag();
    }
    //�������ĵ�Բ���
    public bool firstClick = true;
    public GameObject pen2;
    public GameObject penOption;
    public GameObject penDes;
    public GameObject penOptDes;
    public void ClickPen()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (pen.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        pen.GetComponent<Npc>().ClickTime += 1;
        pen.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            pen.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                pen.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    pen.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        penOptDes.SetActive(false);
        penOption.SetActive(true);
        penDes.SetActive(true);
        book.GetComponent<Npc>().CloseAll();
        ink.GetComponent<Npc>().CloseAll();
        dangangui.GetComponent<Npc>().CloseAll();
    }
    /// <summary>
    /// �״ν���������һ���ж��㣩�����Ϣ�������ý�ɫǨ�����糡
    /// </summary>
    public void Pen()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
       
            GameManager.instance.cards[(int)Card.Information].number += 1;
            penDes.SetActive(false);
            penOptDes.SetActive(true);
            pen.transform.DOLocalMove(new Vector3(-3.08f,7.15f,0), 2);
            pen2.SetActive(true);
        penOption.SetActive(false);
            GetPopup.instance.ShowGets(8);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        
        Bag.instance.UpdateBag();
    }
    //��Ĭ�ĵ�����
    public GameObject danganOption;
    public GameObject danganDes;
    public GameObject danganOptDes; 
    public void ClickDangan()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (dangangui.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        dangangui.GetComponent<Npc>().ClickTime += 1;
        dangangui.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            dangangui.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                dangangui.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    dangangui.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        danganOption.SetActive(true);
        danganDes.SetActive(true);
        pen.GetComponent<Npc>().CloseAll();
        ink.GetComponent<Npc>().CloseAll();
        book.GetComponent<Npc>().CloseAll();
    }
    /// <summary>
    /// ����һ���ж��㣬��ù���
    /// </summary>
   
    public void Desk1()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        GameManager.instance.cards[(int)Card.Story].number += 1;
        GetPopup.instance.ShowGets(0);
        GetPopup.instance.gameObject.SetActive(true);
        GetPopup.instance.work = true;
        Bag.instance.UpdateBag();
    }
    public void Back()
    {
        
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        gameObject.SetActive(false);
        MainMap.instance.gameObject.SetActive(true);
        Bag.instance.detect = false;
        VoiceManager.instance.CloseScence();
        pen.GetComponent<Npc>().CloseAll();
        book.GetComponent<Npc>().CloseAll();
        ink.GetComponent<Npc>().CloseAll();
        dangangui.GetComponent<Npc>().CloseAll();
    }
    private void OnDisable()
    {
        gameObject.SetActive(false);
        MainMap.instance.gameObject.SetActive(true);
        Bag.instance.detect = false;
        pen.GetComponent<Npc>().CloseAll();
        book.GetComponent<Npc>().CloseAll();
        ink.GetComponent<Npc>().CloseAll();
        dangangui.GetComponent<Npc>().CloseAll();
    }
}
