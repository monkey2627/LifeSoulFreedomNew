using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int workPoint;
    public TMP_Text workPointText;
    public int life;
    public TMP_Text lifeText;
    public CardItem[] cards = new CardItem[19];
    public static GameManager instance;
    public Role[] roles = new Role[11];
    //是否每日产生2张觉悟
    public bool doubleAwareness = false;
    //是否每日获得一份金钱
    public bool getMoney = false;
    //免疫疯狂的剩余天数
    public int CrazyFree = 0;
    //是否每日产出一张造物或一张创造
    public bool creation_creativity = false;
    //产出2张造物或者一张创造的时间
    public int creation2_creativity = 0;
    //是否每日获得一份信息
    public bool getInf = false;
    //当天是否选择妒火的面具，每新一天清空
    public bool chooseMask = false;
    //撕毁的卡牌数
    public int cardDestory = 0;
    int chooseMaskDay = 0;
    //概率出现的道具
    public GameObject Book;
    public GameObject Ink;
    public GameObject Mask;
    public GameObject Drum;
    public GameObject Roulette;
    public GameObject Flower;
    public GameObject BadWord;
    void Start()
    {
        instance = this;
    }
    public void AddLife(int n)
    {
        life += n;
        lifeText.text = life.ToString();
    }
        //todo
    public void Init()
    {
        workPoint = 3;
        workPointText.text = workPoint.ToString();
        life = 7;
        lifeText.text = life.ToString();
        for(int i = 0; i < cards.Length; i++)
        {
            cards[i] = new CardItem { card =(Card)i,number = 0};
        }
        cards[(int)Card.Awareness].number = 3;
        Bag.instance.gameObject.SetActive(false);
    }
    /// <summary>
    /// 减少行动值并检测是否进入下一天
    /// </summary>
    public void SubWorkPoint()
    {
        workPoint -= 1;
        workPointText.text = workPoint.ToString();
        if(workPoint == 0)
        {
            //弹出弹窗标志进入下一天
        }
    }

    /// <summary>
    /// 每一天开始时调用
    /// 1.弹出弹窗，获得新卡牌
    /// 2.判定概率角色是否出现
    /// </summary>
    public void NewDay()
    {



        //呢喃的书页
        if(roles[(int)RoleName.Book].show == false)
        {
            int t = Random.Range(1, 3);
            if (t == 2)
            {
                roles[(int)RoleName.Book].show = true;
                roles[(int)RoleName.Book].remain = 1;
                Book.SetActive(true);
            }
        }
        else
        {
            roles[(int)RoleName.Book].remain -= 1;
            if(roles[(int)RoleName.Book].remain == 0)
            {
                roles[(int)RoleName.Book].show = false;
                Book.SetActive(false);
            }
        }
        //哭泣的墨水瓶
        if (roles[(int)RoleName.Ink].show == false)
        {
            int t = Random.Range(1, 3);
            if (t == 2)
            {
                roles[(int)RoleName.Ink].show = true;
                roles[(int)RoleName.Ink].remain = 1;
                Ink.SetActive(true);
            }
        }
        else
        {
            roles[(int)RoleName.Ink].remain -= 1;
            if (roles[(int)RoleName.Ink].remain == 0)
            {
                roles[(int)RoleName.Ink].show = false;
                Ink.SetActive(false);
            }
        }
        //妒火的面具
        if (chooseMask && chooseMaskDay < 3)
        {
            roles[(int)RoleName.Mask].show = true;
            Mask.SetActive(true);
            chooseMaskDay++;
        }
        else
        {
            int t = Random.Range(1, 3);
            if (t == 2)
            {
                roles[(int)RoleName.Mask].show = true;
                Mask.SetActive(true);
                chooseMaskDay = 1;
            }
            else
            {
                roles[(int)RoleName.Mask].show = false;
                Mask.SetActive(false);
            }
        }
        //挑衅的鼓
        if (roles[(int)RoleName.Drum].show == false)
        {
            int t = Random.Range(1, 3);
            if (t == 2)
            {
                roles[(int)RoleName.Drum].show = true;
                roles[(int)RoleName.Drum].remain = 1;
                Drum.SetActive(true);
            }
        }
        else
        {
            roles[(int)RoleName.Drum].remain -= 1;
            if (roles[(int)RoleName.Drum].remain == 0)
            {
                roles[(int)RoleName.Drum].show = false;
                Drum.SetActive(false);
            }
        }
        //荒芜花束,免疫疯狂结束时25%概率出现，每次出现一天
        Flower.SetActive(false);
        if (CrazyFree == 1)
        {
            int t = Random.Range(1, 5);
            if (t == 2)
            {
                roles[(int)RoleName.Flower].show = true;
                Flower.SetActive(true);
            }
        }
        
        //游荡恶语（撕毁2张随机普通牌后出现，每次出现一天）
        BadWord.SetActive(false);
        if(cardDestory %2 ==0 && cardDestory != 0)
        {
            roles[(int)RoleName.BadWord].show = true;
            BadWord.SetActive(true);
        }        
        {
            chooseMask = false;
            Roulette.SetActive(false);
            CrazyFree -= 1;
        }
    }

}
public enum RoleName
{
    Book,
    Ink,
    Mask,
    Drum,
    Roulette,
    Flower,
    BadWord,
}
public struct Role
{
    //还应该出现的天数
    public int remain;
    //今天是否应该出现
    public bool show;
}
public enum Card
{
    //普通
    Cooperation,
    Awareness,
    Trade,
    KnowledgeSeek,
    Luck,
    Desire,
    Creativity,
    Fight,
    //物品
    Money,
    Knowledge,
    Ink,
    Information,
    Story,
    Crazy,
    Awakeness,
    Creation,
    //特殊
    Life,
    Soul,
    Freedom,
        //
        Hope,
        Desperate
}
public struct CardItem
{
    //卡牌种类
    public Card card;
    //卡牌数量
    public int number;
}