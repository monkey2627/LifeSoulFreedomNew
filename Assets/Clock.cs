using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用作钟表的每日问候
/// </summary>
public class Clock : MonoBehaviour
{
    public int type;
    private void OnEnable()
    {
        if (type == 0)
        {
        //    DataManager.instance.cardAddInHello[(int)CardAddInHello.AwarenessHello] += 1;
            GameManager.instance.cards[(int)Card.Awareness].number += 1;
        }
        else
        { 
            GameManager.instance.cards[(int)Card.Awareness].number += 2;
           // DataManager.instance.cardAddInHello[(int)CardAddInHello.AwarenessHello] += 2;
        }
        Bag.instance.UpdateBag();
    }
    public GameObject guide;
}
