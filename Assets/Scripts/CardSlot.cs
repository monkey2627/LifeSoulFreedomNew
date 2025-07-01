using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
    /// <summary>
    /// 对应的选项，在选项处一起初始化
    /// </summary>
    public Option option;
    //本卡槽对应的卡
    public Card card;
    public bool hasCard = false;
    //展示用
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
        //每次放入一个卡之后就判定一下是否能确认
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
