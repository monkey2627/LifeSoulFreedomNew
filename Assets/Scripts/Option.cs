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
    public void ClearAllSlot()
    {
        for (int i = 0; i < cardSlots.Count; i++)
        {
            cardSlots[i].RemoveCard();
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
                    if (GameManager.instance.cards[(int)cardSlots[i].card].number >0)
                    {
                        t += GameManager.instance.cards[(int)cardSlots[i].card].number;
                    }
                }
            }
            if(t >= anyNumber)
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
            Debug.Log(i + "  " + cardSlots[i].hasCard + GameManager.instance.cards[(int)cardSlots[i].card].number + " " + cardsNumber[i]
                   + " " + cardsNumber[i]);
            if (cardSlots[i].hasCard)
            {
                if (GameManager.instance.cards[(int)cardSlots[i].card].number >= cardsNumber[i]
                    && cardsNumber[i] != 0)
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
            if(cardSlots[0].hasCard && cardSlots[1].hasCard)
            {
                GameManager.instance.cards[(int)cardSlots[0].card].number -= 1;
                GameManager.instance.cards[(int)cardSlots[1].card].number -= 1;
            }
            else if (cardSlots[0].hasCard && !cardSlots[1].hasCard)
            {
                GameManager.instance.cards[(int)cardSlots[0].card].number -= 2;
            }
            else if (!cardSlots[0].hasCard && cardSlots[1].hasCard)
            {
                GameManager.instance.cards[(int)cardSlots[1].card].number -= 2;
            }
            Bag.instance.UpdateBag();
            for (int i = 0; i < cardSlots.Count; i++)
            {
                cardSlots[i].RemoveCard();
            }
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
