using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeArea : MonoBehaviour
{
    //����루������һֻ���ӵ��飬��פ����
///����һ���ж��㣬ʹ��һ�ž��򣬻����Ϣ�����ܣ�25%�������֪
        public void Dove1()
    {

        GameManager.instance.cards[(int)Card.Desire].number -= 1;
        GameManager.instance.cards[(int)Card.Awareness].number -= 1;
        GameManager.instance.AddLife(3);
        int t = Random.Range(1, 3);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Luck].number += 1;
        }

    }
    /// <summary>
    ///  ����һ���ж��㣬ʹ��һ�Ŵ��죬���5��Ǯ���׻������34%��33%��33%��
    /// </summary>
    public void Dove2()
    {

        GameManager.instance.cards[(int)Card.Desire].number -= 1;
        GameManager.instance.cards[(int)Card.Awareness].number -= 1;
        GameManager.instance.AddLife(3);
        int t = Random.Range(1, 3);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Luck].number += 1;
        }

    }
    /// <summary>
    /// ����һ���ж��㣬ʹ��һ����Ϣ�����2��Ǯ
    /// </summary>
    public void Dove3()
    {

        GameManager.instance.cards[(int)Card.Desire].number -= 1;
        GameManager.instance.cards[(int)Card.Awareness].number -= 1;
        GameManager.instance.AddLife(3);
        int t = Random.Range(1, 3);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Luck].number += 1;
        }

    }
   


//��ƽ�ĳӣ���פ��
        /// <summary>
        /// ����һ���ж��㣬ʹ��һ�ž����3��Ǯ�����������ܣ�25%����ô���
        /// </summary>
         public void Cheng1()
        {

            GameManager.instance.cards[(int)Card.Money].number -= 3;
            GameManager.instance.cards[(int)Card.Awareness].number -= 1;
            GameManager.instance.cards[(int)Card.Creation].number += 1;
            int t = Random.Range(1, 5);
            if (t == 2)
            {
                GameManager.instance.cards[(int)Card.Creativity].number += 1;
            }

         }
    /// <summary>
    /// ����һ���ж��㣬ʹ��12��Ǯ�����������ܣ�50%����ú���/����/������34%/33%/33%��
    /// </summary>
    public void Cheng2()
    {

        GameManager.instance.cards[(int)Card.Money].number -= 12;
        GameManager.instance.cards[(int)Card.Creation].number += 1;
        int t = Random.Range(1, 3);
        if (t == 2)
        {
            t = Random.Range(1, 4);
            if (t == 1)
            {
                GameManager.instance.cards[(int)Card.Cooperation].number += 1;
            }else if (t == 2)
            {
                GameManager.instance.cards[(int)Card.Trade].number += 1;
            }
            else
            {
                GameManager.instance.cards[(int)Card.Desire].number += 1;
            }
        }

    }/// <summary>
     /// ����һ���ж��㣬ʹ��һ�ž����һ��������4��Ǯ�����ܣ�25%����ú���
    /// </summary>
    public void Cheng3()
    {
        GameManager.instance.cards[(int)Card.Creation].number -= 1;
        GameManager.instance.cards[(int)Card.Awareness].number -= 1;
        GameManager.instance.cards[(int)Card.Money].number += 4;
        int t = Random.Range(1, 5);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Cooperation].number += 1;
        }
    }
    /// <summary>
    /// ����һ���ж��㣬ʹ��һ��������1��Ǯ
    /// </summary>
    public void Cheng4()
    {
        GameManager.instance.cards[(int)Card.Creation].number -= 1;
        GameManager.instance.cards[(int)Card.Money].number += 1;
    }
}
