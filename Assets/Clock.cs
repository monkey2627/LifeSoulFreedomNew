using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用作钟表的每日问候
/// </summary>
public class Clock : MonoBehaviour
{
    /// <summary>
    /// 获得一张觉悟
    /// </summary>
    public void Option1()
    {
        GameManager.instance.cards[(int)Card.Awareness].number++;
        gameObject.SetActive(false);
    }
    public GameObject guide;

    /// <summary>
    /// 我已做好觉悟，这次一定要追上你。
    /// </summary>
    public void Option2()
    {
        guide.SetActive(true);
        GameManager.instance.cards[(int)Card.Awareness].number -=3;
        gameObject.SetActive(false);
    }
}
