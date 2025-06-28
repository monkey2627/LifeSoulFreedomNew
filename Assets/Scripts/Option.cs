using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public bool anyNormal = false;
    public int anyNumber = 0;
    //��ѡ�����ĵĿ���
    public Card[] cards;
    //��ѡ�����ĵĿ��ƶ�Ӧ����
    public int[] cardsNumber;
    //��ѡ���Ӧ�Ŀ���
    public List<CardSlot> cardSlots;
    //����ȷ��
    public GameObject ok;
    //����ȷ��
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
    /// ������Ƿ�����Ҫ��
    /// </summary>
    public bool Check()
    {
        if (anyNormal)
        {
            int t = 0;
            for (int i = 0; i < cardSlots.Count; i++)
            {
                if (cardSlots[i].hasCard)
                {
                    if (GameManager.instance.cards[(int)cardSlots[i].card].number >0
                        && cardsNumber[(int)cardSlots[i].card] != 0)
                    {
                        t++;
                    }
                }
            }
            if(t == anyNumber)
            {
                ok.SetActive(true);
                notOk.SetActive(false);
                return true;
            }
            ok.SetActive(false);
            notOk.SetActive(true);
            return false;


        }
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
                ok.SetActive(false);
                notOk.SetActive(true);
                return false;
               
            }
        }
        ok.SetActive(true);
        notOk.SetActive(false);
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


    public void SubCard()
    {
        if (anyNormal)
        {
            for (int i = 0; i < cardSlots.Count; i++)
            {
                if (cardSlots[i].hasCard)
                {
                    GameManager.instance.cards[(int)cardSlots[i].card].number -= 1;
                }
            }
            Bag.instance.UpdateBag();
            return;
        }
        for (int i = 0; i < cards.Length; i++)
        {
            
            GameManager.instance.cards[(int)cards[i]].number -= cardsNumber[i];
            
        }
        for (int i = 0; i < cardSlots.Count; i++)
        {
            cardSlots[i].RemoveCard();
        }

    }

}
