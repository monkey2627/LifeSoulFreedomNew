using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant : MonoBehaviour
{
    /// <summary>
    /// 不消耗行动点，使用1金钱，获得2饱食
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
    /// 不消耗行动点，使用一张觉悟和1金钱，获得3饱食，可能（25%）获得欲望
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
    /// 不消耗行动点，使用一张欲望获得5饱食
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
    /// 不消耗行动点，使用一张欲望和一张觉悟获得5饱食，可能（50%）获得幸运
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
