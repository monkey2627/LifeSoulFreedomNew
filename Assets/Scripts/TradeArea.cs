using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeArea : MonoBehaviour
{
    //藏书鸽（封面是一只鸽子的书，常驻）：
///消耗一点行动点，使用一张觉悟，获得信息，可能（25%）获得求知
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
    ///  消耗一点行动点，使用一张创造，获得5金钱或交易或合作（34%，33%，33%）
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
    /// 消耗一点行动点，使用一份信息，获得2金钱
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
   


//公平的秤（常驻）
        /// <summary>
        /// 消耗一点行动点，使用一张觉悟和3金钱，获得造物，可能（25%）获得创造
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
    /// 消耗一点行动点，使用12金钱，获得造物，可能（50%）获得合作/交易/欲望（34%/33%/33%）
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
     /// 消耗一点行动点，使用一张觉悟和一张造物，获得4金钱，可能（25%）获得合作
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
    /// 消耗一点行动点，使用一张造物获得1金钱
    /// </summary>
    public void Cheng4()
    {
        GameManager.instance.cards[(int)Card.Creation].number -= 1;
        GameManager.instance.cards[(int)Card.Money].number += 1;
    }
}
