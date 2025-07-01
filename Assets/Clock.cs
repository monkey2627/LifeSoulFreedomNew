using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ӱ��ÿ���ʺ�
/// </summary>
public class Clock : MonoBehaviour
{
    public int type;
    private void OnEnable()
    {
        if(type == 0)
        GameManager.instance.cards[(int)Card.Awareness].number += 1;
        else
            GameManager.instance.cards[(int)Card.Awareness].number += 2;
        Bag.instance.UpdateBag();
    }
    /// <summary>
    /// ���һ�ž���
    /// </summary>
    public void Option1()
    {
        GameManager.instance.cards[(int)Card.Awareness].number++;
        gameObject.SetActive(false);
        GameManager.instance.NextHello();
    }
    public GameObject guide;

    /// <summary>
    /// �������þ������һ��Ҫ׷���㡣
    /// </summary>
    public void Option2()
    {
        if (GameManager.instance.cards[(int)Card.Awareness].number >= 3)
        {
            guide.SetActive(true);
            GameManager.instance.cards[(int)Card.Awareness].number -= 3;
            gameObject.SetActive(false);
        }
    }
}
