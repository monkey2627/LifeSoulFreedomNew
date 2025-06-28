using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{

    //��૵���ҳ
    /// <summary>
    /// ����һ���ж��㣬����2��Ǯ���һ��֪ʶ
    /// </summary>
    public void Book1()
    {
        
            GameManager.instance.cards[(int)Card.Money].number -= 2;
            GameManager.instance.cards[(int)Card.Knowledge].number += 1;
        GameManager.instance.SubWorkPoint();

    }
    /// <summary>
    /// ����һ���ж��㣬����2��Ǯ��һ�ž�����һ��֪ʶ�����ܣ�25%�������֪
    /// </summary>
    public void Book2()
    {
       
            GameManager.instance.cards[(int)Card.Money].number -= 2;
            GameManager.instance.cards[(int)Card.Awareness].number -= 1;
            GameManager.instance.cards[(int)Card.Knowledge].number += 1;
            int t = Random.Range(1, 5);
            if(t == 2)
            {
              GameManager.instance.cards[(int)Card.KnowledgeSeek].number += 1;
            }
        GameManager.instance.SubWorkPoint();

    }
    /// <summary>
    /// ����һ���ж��㣬��3��īˮ��ȡһ����Ϣ/��֪/���ˣ�50%/25%/25%��
    /// </summary>
    public void Book3()
    {
       
        GameManager.instance.cards[(int)Card.Ink].number -= 3;
        int t = Random.Range(1, 5);
        if (t == 2 || t == 1)
        {
            GameManager.instance.cards[(int)Card.Information].number += 1;
        }
        else if (t == 3)
        {
            GameManager.instance.cards[(int)Card.KnowledgeSeek].number += 1;
        }
        else if (t == 4)
        {
            GameManager.instance.cards[(int)Card.Luck].number += 1;
        }
        GameManager.instance.SubWorkPoint();

    }
    //������īˮƿ
    /// <summary>
    /// ����һ���ж��㣬��2��֪ʶ��ȡ������֪
    /// </summary>
    public void Ink1()
    {
      
            GameManager.instance.cards[(int)Card.Knowledge].number -= 2;
            GameManager.instance.cards[(int)Card.KnowledgeSeek].number += 1;
       
        GameManager.instance.SubWorkPoint();
    }
    /// <summary>
    /// ����һ���ж��㣬���ܣ�10%�����īˮ
    /// </summary>
    public void Ink2()
    {
        int t = Random.Range(1, 11);
        if(t == 2)
        {
            GameManager.instance.cards[(int)Card.Ink].number += 1;
        }
        GameManager.instance.SubWorkPoint();
    }
    /// <summary>
    /// ����һ���ж��㣬ʹ��һ�ź�������ô���/��֪��50%/50%��
    /// </summary>
    public void Ink3()
    {
            GameManager.instance.cards[(int)Card.Cooperation].number -= 1;
            int t = Random.Range(1, 3);
            if (t == 2)
            {
                GameManager.instance.cards[(int)Card.Creativity].number += 1;

            }
            else
            {
                GameManager.instance.cards[(int)Card.KnowledgeSeek].number += 1;
            }
        
        GameManager.instance.SubWorkPoint();
    }
    //�������ĵ�Բ���
    public bool firstClick = true;
    public GameObject pen1;
    public GameObject pen2;
    /// <summary>
    /// �״ν���������һ���ж��㣩�����Ϣ�������ý�ɫǨ�����糡
    /// </summary>
    public void Pen()
    {
        if (firstClick)
        {
            firstClick = false;
            GameManager.instance.cards[(int)Card.Information].number += 1;
            //todo Բ�����ʧ�Ķ���

            pen2.SetActive(true);
        }
        GameManager.instance.SubWorkPoint();
    }
    //��Ĭ�ĵ�����
    /// <summary>
    /// ����һ���ж��㣬��ù���
    /// </summary>
    public void Desk1()
    {
        GameManager.instance.cards[(int)Card.Story].number += 1;
        GameManager.instance.SubWorkPoint();
    }
    
}
