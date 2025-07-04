using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPopup : MonoBehaviour
{
    public GameObject[] gets;
    public static GetPopup instance;
    public bool work = false;
    int getNow;
    private void Awake()
    {
        getNow = -1;
        instance = this;
        gameObject.SetActive(false);
    }

    public void ShowGets(int t)
    {
        for(int i = 0; i < gets.Length; i++)
        {
            gets[i].SetActive(false);
        }
        gets[t].SetActive(true);
        getNow = t;
    }
    public GameObject story;
    private void OnDisable()
    {
        if (getNow == 31)
        {
            DataManager.instance.SaveGame();
        }
        if (work && getNow != 0 && getNow !=15 && getNow != 3)
        {
            GameManager.instance.SubWorkPoint();
        }
        //故事
        if(getNow == 0)
        {
            story.SetActive(true);
        }
        //清明
        if(getNow == 15)
        {
            if (GameManager.instance.cards[(int)Card.Awakeness].number % 3 == 0 && GameManager.instance.cards[(int)Card.Awakeness].number > 0)
            {
                DataManager.instance.CrazyFree = 5;
                Theater.instance.WufaFengkuang.SetActive(true);
            }
            else
            {
               
                GameManager.instance.SubWorkPoint();
            }
        }
        //撕毁牌
        if(getNow ==3)
        {
            if (GameManager.instance.cards[(int)Card.Crazy].number % 3 == 0 
                && GameManager.instance.cards[(int)Card.Crazy].number > 0
               && GameManager.instance.crazy[GameManager.instance.cards[(int)Card.Crazy].number / 3] == 0
               && GameManager.instance.cards[0].number == 0
               && GameManager.instance.cards[1].number == 0
               && GameManager.instance.cards[2].number == 0
               && GameManager.instance.cards[3].number == 0
               && GameManager.instance.cards[4].number == 0
               && GameManager.instance.cards[5].number == 0
               && GameManager.instance.cards[6].number == 0
               && GameManager.instance.cards[7].number == 0)
            {
                GameManager.instance.NextDayMust();

            }else if (GameManager.instance.cards[(int)Card.Crazy].number % 3 == 0 
                && GameManager.instance.cards[(int)Card.Crazy].number > 0
                && GameManager.instance.crazy[GameManager.instance.cards[(int)Card.Crazy].number / 3] == 0)
            {

                int card = Theater.instance.find();
                GameManager.instance.cards[card].number -= 1;
                DataManager.instance.CardDestroy++;
                string text = "撕毁一张" + Theater.instance.deses[card] + "。";
                Theater.instance.maskTextp.SetActive(true);
                Theater.instance.maskText.text = text;
                GameManager.instance.crazy[GameManager.instance.cards[(int)Card.Crazy].number / 3] = 1;
                Bag.instance.UpdateBag();
            }
            else
            {
                GameManager.instance.SubWorkPoint();
                Bag.instance.UpdateBag();
            }
        }
    }
}