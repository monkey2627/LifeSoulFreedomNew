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
    public void PushCard(Card card)
    {
        hasCard = true;
        cards[(int)this.card].SetActive(false);
        this.card = card;
        cards[(int)this.card].SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
