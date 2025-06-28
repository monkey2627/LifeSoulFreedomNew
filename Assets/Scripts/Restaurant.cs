using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant : MonoBehaviour
{
    /// <summary>
    /// �������ж��㣬ʹ��1��Ǯ�����2��ʳ
    /// </summary>
    public void Lobster1()
    {
        if(GameManager.instance.cards[(int)Card.Money].number >= 1)
        {
            GameManager.instance.cards[(int)Card.Money].number -= 1;
            GameManager.instance.AddLife(2);
        }
    }
    /// <summary>
    /// �������ж��㣬ʹ��һ�ž����1��Ǯ�����3��ʳ�����ܣ�25%���������
    /// </summary>
    public void Lobster2()
    {
        if (GameManager.instance.cards[(int)Card.Money].number >= 1 &&
            GameManager.instance.cards[(int)Card.Awareness].number >= 1)
        {
            GameManager.instance.cards[(int)Card.Money].number -= 1;
            GameManager.instance.cards[(int)Card.Awareness].number -= 1;
            GameManager.instance.AddLife(3);
            int t = Random.Range(1, 5);
            if (t == 2)
            {
                GameManager.instance.cards[(int)Card.Desire].number += 1;
            }
        }
    }
    /// <summary>
    /// �������ж��㣬ʹ��һ���������5��ʳ
    /// </summary>
    public void Lobster3()
    {
        if (GameManager.instance.cards[(int)Card.Desire].number >= 1)
        {
            GameManager.instance.cards[(int)Card.Desire].number -= 1;
            GameManager.instance.AddLife(5);
        }
    }
    /// <summary>
    /// �������ж��㣬ʹ��һ��������һ�ž�����5��ʳ�����ܣ�50%���������
    /// </summary>
    public void Lobster4()
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
}
