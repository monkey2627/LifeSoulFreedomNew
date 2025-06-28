using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theater : MonoBehaviour
{
    public GameObject pen;
    public GameObject mask;
    public GameObject drum;
    public GameObject flower;
    public GameObject badWords;
    public GameObject lunPan;
    public GameObject tanxi;
    int find()
    {
        while (true)
        {
            int t = Random.Range(0, 20);
            if(GameManager.instance.cards[t].number > 0)
            {
                return t;
            }
        }
    }
    //�ʻ�����
    /// <summary>
    /// ����һ���ж��㣬���һ�ݷ�񣬻���3�ݷ���˺��һ�������ͨ��
    /// </summary>
    public void Mask1()
    {
        GameManager.instance.chooseMask = true;
        GameManager.instance.cards[(int)Card.Crazy].number += 1;
        if(GameManager.instance.cards[(int)Card.Crazy].number == 3)
        {
            //������
            if (GameManager.instance.CrazyFree <= 0)
            {
                //todo ���˺��һ����ͨ��
                int card = find();
            }
        }
        //todo �˴�����ʾ˺��֮����ת����һ��
       // GameManager.instance.SubWorkPoint();
    }
    //̾Ϣ֮Ļ����פ)
    public void Tanxi1()
    {
        //todo �ۿ��Լ��ķ��
        if(GameManager.instance.cards[(int)Card.Crazy].number >= 1) {
            GameManager.instance.cards[(int)Card.Crazy].number -= 1;
            GameManager.instance.cards[(int)Card.Awakeness].number += 1;
            if(GameManager.instance.cards[(int)Card.Awakeness].number == 3)
            {
                GameManager.instance.CrazyFree = 4;
            }

        }
    }
    public void Tanxi2()
    {
        if (GameManager.instance.cards[(int)Card.Crazy].number >= 6)
        {
            GameManager.instance.cards[(int)Card.Crazy].number -= 6;
            int t = Random.Range(1, 11);
            if (t <=7)
            {
                GameManager.instance.cards[(int)Card.Desire].number += 1;
            }
            else
            {
                GameManager.instance.cards[(int)Card.Luck].number += 1;
            }
        }
    }
    //���ƵĹ�
    /// <summary>
    /// ����һ���ж��㣬��1�ݷ���1�ݾ����ٻ�һ�μ��������
    /// </summary>
    public void Gu()
    {
          GameManager.instance.cards[(int)Card.Crazy].number -= 1;
          GameManager.instance.cards[(int)Card.Awareness].number -= 1;
        //todo ���ּ�������̵Ķ�������������֮��GameManager.instance.SubWorkPoint();


    }
    //���������
    /// <summary>
    /// �������ж��㣬�����ƵĹĽ��������ڵ�ʯͷ�����������̵����ֻ���ʯͷ����������
    /// ʤ������3��Ǯ��ʧ������1�������ʤ��3�κ���һ������
    /// </summary>
    public void Roulette()
    {
        //�������̣���ʼʯͷ������
        startGame = true;
    }
    bool startGame = false;
    public GameObject[] sjb;
    //�������ĵ�Բ��ʣ���פ)
    public GameObject penOption;
    public GameObject penDes;
    public void ClickPen()
    {
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
        penOption.SetActive(true);
        penDes.SetActive(true);
    }
    /// <summary>
    /// ����һ���ж��㣬ʹ��һ�ž�������Ϣ��1��Ǯ�����ܣ�10%���������
    /// </summary>
    public void Pen1()
    {
        GameManager.instance.cards[(int)Card.Information].number += 1;
        GameManager.instance.cards[(int)Card.Money].number += 1;
        int t = Random.Range(1, 11);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Fight].number += 1;
        }
        GameManager.instance.SubWorkPoint();
        Bag.instance.UpdateBag();
    }
    /// <summary>
    /// ����һ���ж��㣬ʹ��2��������ͨ�ƻ��һ��������һ�ź���
    /// </summary>
    public void Pen2()
    {
        int t = Random.Range(1, 3);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Fight].number += 1;
        }
        else
        {
            GameManager.instance.cards[(int)Card.Cooperation].number += 1;
        }
        GameManager.instance.SubWorkPoint();
        Bag.instance.UpdateBag();
    }
    //���߻���
    /// <summary>
    /// �������ж��㣬���һ������/ϣ����������3������+1����80%/20%��
    /// </summary>
    public void Flower()
    {
        int t = Random.Range(1, 6);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Hope].number += 3;
        }
        else
        {
            GameManager.instance.cards[(int)Card.Luck].number += 1;
        }
    }
    /// <summary>
    /// �ε����˺��2�������ͨ�ƺ���֣�ÿ�γ���һ�죩��
    /// �������ж��㣬���һ������/������������3������-1����50%/50%��
    /// </summary>
    public void BadWord()
    {
        int t = Random.Range(1, 3);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Desperate].number += 3;
        }
        else
        {
            GameManager.instance.cards[(int)Card.Fight].number += 1;
        }
    }
    public GameObject mainMap;
    public void Back()
    {
        gameObject.SetActive(false);
        mainMap.SetActive(true);
        Bag.instance.detect = false;
    }
}
