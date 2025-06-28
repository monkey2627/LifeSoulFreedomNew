using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    //该选项消耗的卡牌
    public Card[] cards;
    //该选项消耗的卡牌对应数量
    public int[] cardsNumber;
    //该选项对应的卡槽
    public List<CardSlot> cardSlots;
    //可以确定
    public GameObject ok;
    //不能确定
    public GameObject notOk;
    private void Start()
    {
        cardSlots = new List<CardSlot>();
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.GetComponent<CardSlot>())
            {
                cardSlots.Add(transform.GetChild(i).GetComponent<CardSlot>());
                transform.GetChild(i).GetComponent<CardSlot>().option = this;
            }
        }
    }
    /// <summary>
    /// 检查牌是否满足要求
    /// </summary>
    public bool Check()
    {
        int[] a=new int[19];
        for(int i = 0; i < 19; i++)
        {
            a[i] = 0;
        }
        for(int i = 0; i < cards.Length; i++)
        {
            a[(int)cards[i]]++;
        }
        for (int i = 0; i < cardSlots.Count; i++)
        {
            if (cardSlots[i].hasCard)
            {
                if (GameManager.instance.cards[(int)cardSlots[i].card].number >= cardsNumber[(int)cardSlots[i].card]
                    && cardsNumber[(int)cardSlots[i].card] != 0)
                { 
                    a[(int)cardSlots[i].card]--; 
                }
            }
           
        }
        for (int i = 0; i < 19; i++)
        {
            
            if(a[i] != 0)
            {
                return false;
            }
        }
        return true;
    }

    public bool CheckIfHas(int card)
    {
        for (int i = 0; i < cardSlots.Count; i++)
        {
            if (cardSlots[i].hasCard)
            {
                if((int)cardSlots[i].card == card)
                {
                    return true;
                }
               
            }

        }
        return false;
    }
}
