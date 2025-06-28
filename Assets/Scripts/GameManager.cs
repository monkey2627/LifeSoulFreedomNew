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
    public CardItem[] cards = new CardItem[22];
    public static GameManager instance;
    public Role[] roles = new Role[11];
    //是否每日产生2张觉悟
    public bool doubleAwareness = false;
    public int doubleAwarenessDay = 0;
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
    public void Init()
    {
        workPoint = 3;
        workPointText.text = workPoint.ToString();
        life = 7;
        lifeText.text = life.ToString();
        for(int i = 0; i < 22; i++)
        {
            cards[i] = new CardItem { card =(Card)i,number = 0};
        }
        cards[(int)Card.Awareness].number = 3;
        Bag.instance.gameObject.SetActive(false);
    }
    public GameObject ClockDay1;
    public GameObject ClockDay1_4;
    public GameObject ClockDay5;
    public GameObject Sholve1;
    public GameObject Sholve1_4;
    public GameObject Sholve5;
    /// <summary>
    /// 减少行动值并检测是否进入下一天
    /// </summary>
    public void SubWorkPoint()
    {
        workPoint -= 1;
        workPointText.text = workPoint.ToString();
        if(workPoint == 0)
        {
            //刷新两个体力
            workPoint = 3;
            workPointText.text = workPoint.ToString();
            life -= 1;
            lifeText.text = life.ToString();
            if (life > 0)
            {
                SolveDayHello();
            }
        }
    }
    public void SolveDayHello()
    {
        Bag.instance.gameObject.SetActive(false);
        //先一个一个处理每日问候，加入hellos
        //钟
        if (cards[(int)Card.Hope].number > 0)
        {
            if (doubleAwareness)
            {
                if (doubleAwarenessDay == 1)
                {
                    hellos.Add(ClockDay5);
                }
                else
                {
                    hellos.Add(ClockDay1_4);
                }
            }
            else
            {
                hellos.Add(ClockDay1);
            }
        }
        if (doubleAwareness)
        {
            if (doubleAwarenessDay == 1)
            {
                hellos.Add(ClockDay5);
            }
            else
            {
                hellos.Add(ClockDay1_4);
            }
        }
        else
        {
            hellos.Add(ClockDay1);
        }
        if (cards[(int)Card.Desperate].number > 0)
        {
            hellos.RemoveAt(hellos.Count - 1);
        }
        //园艺铲子
        if (cards[(int)Card.Hope].number > 0)
        {
            if (creation2_creativity == 1)
            {
                hellos.Add(Sholve5);
            }
            else if (creation2_creativity > 0)
            {
                hellos.Add(Sholve1_4);
            }
            else if (creation_creativity)
            {
                hellos.Add(Sholve1);
            }
        }
        if (creation2_creativity == 1)
        {
            hellos.Add(Sholve5);
        }
        else if (creation2_creativity > 0)
        {
            hellos.Add(Sholve1_4);
        }
        else if (creation_creativity)
        {
            hellos.Add(Sholve1);
        }
        if (cards[(int)Card.Desperate].number > 0)
        {
            hellos.RemoveAt(hellos.Count - 1);
        }

    
}
    public GameObject clock;
    public GameObject sholve;
    //每次把所有需要每日问候的东西加进去，按顺序来
    public List<GameObject> hellos;
    public void NextHello()
    {
        if(hellos.Count > 0)
        {
            hellos[0].SetActive(true);
            hellos.RemoveAt(0);
        }
        else
        {
            //每日问候处理完了
            NewDay();
        }
    }
    /// <summary>
    /// 每一天开始在每日问候处理完调用
    /// 1.弹出弹窗，获得新卡牌
    /// 2.判定概率角色是否出现
    /// </summary>
    public void NewDay()
    {
        Bag.instance.gameObject.SetActive(true);
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
            doubleAwarenessDay -= 1;
            if(doubleAwarenessDay == 0)
            {
                doubleAwareness = false;
                clock.SetActive(true);
            }
            creation2_creativity -= 1;
            if(creation2_creativity == 0)
            {
                sholve.SetActive(true);
            }

            if(cards[(int)Card.Hope].number > 0)
            {
                cards[(int)Card.Hope].number -= 1;
            }
            if (cards[(int)Card.Desperate].number > 0)
            {
                cards[(int)Card.Desperate].number -= 1;
            }

        }
    }
    public GameObject[] scenceEnters;
    public void EnableAll()
    {
        for(int i = 0; i < scenceEnters.Length; i++)
        {
            scenceEnters[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    public void DisableAll()
    {
        for (int i = 0; i < scenceEnters.Length; i++)
        {
            scenceEnters[i].GetComponent<BoxCollider2D>().enabled = false;
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