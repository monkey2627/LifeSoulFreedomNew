using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ӱ��ÿ���ʺ�
/// </summary>
public class Clock : MonoBehaviour
{
    /// <summary>
    /// ���һ�ž���
    /// </summary>
    public void Option1()
    {
        GameManager.instance.cards[(int)Card.Awareness].number++;
        gameObject.SetActive(false);
    }
    public GameObject guide;

    /// <summary>
    /// �������þ������һ��Ҫ׷���㡣
    /// </summary>
    public void Option2()
    {
        guide.SetActive(true);
        GameManager.instance.cards[(int)Card.Awareness].number -=3;
        gameObject.SetActive(false);
    }
}
