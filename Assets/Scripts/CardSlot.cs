using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
    /// <summary>
    /// ��Ӧ��ѡ���ѡ�һ���ʼ��
    /// </summary>
    public Option option;
    //�����۶�Ӧ�Ŀ�
    public Card card;
    public bool hasCard = false;
    //չʾ��
    public GameObject[] cards;
    void Start()
    {
        
    }
    public void MoveCardBack()
    {
        for(int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.position = new Vector3(cards[i].transform.position.x, cards[i].transform.position.y, 0);
        }
    }
    public void MoveCardUp()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.position = new Vector3(cards[i].transform.position.x, cards[i].transform.position.y, -1);
        }
    }
    public void PushCard(Card card)
    {
        hasCard = true;
        cards[(int)this.card].SetActive(false);
        this.card = card;
        cards[(int)this.card].SetActive(true);
        //ÿ�η���һ����֮����ж�һ���Ƿ���ȷ��
        VoiceManager.instance.InsertCard();
        option.Check();
    }
    public void RemoveCard()
    {
        hasCard = false;
        cards[(int)card].SetActive(false);
        option.Check();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
