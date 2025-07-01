using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public int workPoint;
    public GameObject[] workPoints;
    public int life;
    public GameObject[] lifes;
  
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
    //获得的清明总数
    public int awakeNumber = 0;
    //概率出现的道具
    public GameObject Book;
    public GameObject Ink;
    public GameObject Mask;
    public GameObject Drum;
    public GameObject Roulette;
    public GameObject Flower;
    public GameObject BadWord;

    public bool TanChuangZhuangTai = false;

    void Awake()
    {
        instance = this;
    }
    public void AddLife(int n)
    {
        life += n;
        if (life > 7)
            life = 7;
        for(int i = 0; i < lifes.Length; i++){
            lifes[i].SetActive(false);
        }
        lifes[life - 1].SetActive(true);
    }
    public void Life()
    {
        for (int i = 0; i < lifes.Length; i++)
        {
            lifes[i].SetActive(false);
        }
        if(life>0)
            lifes[life - 1].SetActive(true);
    }
    public void Work()
    {
        for (int i = 0; i < workPoints.Length; i++)
        {
            workPoints[i].SetActive(false);
        }
        if(workPoint>0)
            workPoints[workPoint - 1].SetActive(true);
    }
    public GameObject UII;
    public void NextDay()
    {
        if (TanChuangZhuangTai)
            return;
        //刷新两个体力
        workPoint = 3;
        life -= 1;
        if (life == 0)
        {
            noLife.SetActive(true);
        }
        Work();
        Life();
        Debug.Log("next");
        mainMap.SetActive(true);
        home.SetActive(false);
        lib.SetActive(false);
        the.SetActive(false);
        trade.SetActive(false);
        garden.SetActive(false);
        res.SetActive(false);
        bridge.SetActive(false);
        home.SetActive(false);
        SolveDayHello();
    }
    public void NextDayMust()
    {
        //刷新两个体力
        workPoint = 3;
        life -= 1;
        if (life == 0)
        {
            noLife.SetActive(true);
        }
        Work();
        Life();
        Debug.Log("next");
        mainMap.SetActive(true);
        home.SetActive(false);
        lib.SetActive(false);
        the.SetActive(false);
        trade.SetActive(false);
        garden.SetActive(false);
        res.SetActive(false);
        bridge.SetActive(false);
        home.SetActive(false);
        SolveDayHello();
    }
    /// <summary>
    /// 在播放完动画之后会触发
    /// </summary>
    public void Init()
    {
        //刷新体力和饱腹
        workPoint = 3;
        Work();
        life = 7;
        Life();
        //刷新卡牌
        for(int i = 0; i < 22; i++)
        {
            cards[i] = new CardItem { card =(Card)i,number = 0};
        }
        cards[(int)Card.Awareness].number = 3;
        //把背包关上，调整背包位置
        Bag.instance.gameObject.SetActive(false);
        Bag.instance.gameObject.transform.position = new Vector3(9.05f, -0.3f, -1.6f);
        //todo 清空所有特殊状态
        if (Home.instance)
            Home.instance.painted = false;
        for(int i = 0; i < crazy.Length; i++)
        {
            crazy[i] = 0;
        }
        //todo 将所有场景还原为初始状态
    }
    public GameObject ClockDay1;
    public GameObject ClockDay1_4;
    public GameObject ClockDay5;
    public GameObject Sholve1;
    public GameObject Sholve1_4;
    public GameObject Sholve5;
    public GameObject canvas;
    public GameObject worldTree;

    public GameObject noLife;
    public GameObject noWorkPoint;
    /// <summary>
    /// 减少行动值并检测是否进入下一天
    /// </summary>
    public void SubWorkPoint()
    {
        workPoint -= 1;
        Work();
        if(workPoint == 0)
        {

            //刷新两个体力
            workPoint = 3;
            Work();
            life -= 1;
            Life();
            if (life > 0)
            {
                noWorkPoint.SetActive(true);
            }
            else
            {
                noLife.SetActive(true);
            }
        }
    }
    public void SolveDayHello()
    {
        Bag.instance.UpdateBag();
        DisableAll();
        Debug.Log("solveHello");
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
        //画布
        if (cards[(int)Card.Hope].number > 0)
        {
            if (getMoney)
            {
                hellos.Add(canvas);
            }
        }
        if (getMoney)
        {
            hellos.Add(canvas);   
        }
        if (cards[(int)Card.Desperate].number > 0)
        {
            hellos.RemoveAt(hellos.Count - 1);
        }
        //世界树
        if (cards[(int)Card.Hope].number > 0)
        {
            if (getInf)
            {
                hellos.Add(worldTree);
            }
        }
        if (getInf)
        {
            hellos.Add(worldTree);
        }
        if (cards[(int)Card.Desperate].number > 0)
        {
            hellos.RemoveAt(hellos.Count - 1);
        }
        if (hellos.Count > 0)
        {
            hellos[0].SetActive(true);
            hellos.RemoveAt(0);
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
    public GameObject lib;
    public GameObject bridge;
    public GameObject the;
    public GameObject res;
    public GameObject trade;
    public GameObject garden;
    public GameObject home;
    public GameObject mainMap;
    public void ClickLib()
    {
        if (!enable) return;
        lib.SetActive(true);
        mainMap.SetActive(false);
        VoiceManager.instance.IntoScene();
        OpenScence();
    }
    public void ClickBri()
    {
        if (!enable) return;
        bridge.SetActive(true);
        mainMap.SetActive(false);
        OpenScence();
    }
    public void ClickThe()
    {
        if (!enable) return;
        the.SetActive(true);
        mainMap.SetActive(false);
        VoiceManager.instance.IntoScene();
        OpenScence();
    }
    public void Clickres()
    {
        if (!enable) return;
        res.SetActive(true);
        mainMap.SetActive(false);
        VoiceManager.instance.IntoScene();
        OpenScence();
    }
    public void ClickTrade()
    {
        if (!enable) return;
        trade.SetActive(true);
        mainMap.SetActive(false);
        VoiceManager.instance.IntoScene();
        OpenScence();
    }
    public void ClickGar()
    {
      
        if (!enable) return;  
        Debug.Log("1");
        garden.SetActive(true);
        mainMap.SetActive(false);
        VoiceManager.instance.IntoScene();
        OpenScence();
    }
    public void ClickHOme()
    {
        if (!enable) return;
        home.SetActive(true);
        mainMap.SetActive(false);
        VoiceManager.instance.IntoScene();
        OpenScence();
    }
    public void OpenScence()
    {
        Debug.Log("openScene");
        Bag.instance.UpdateBag();
        Bag.instance.detect = true;
        Bag.instance.transform.DOMove(new Vector3(5.49f, -0.3f, -1.6f), 2).OnComplete(() => {
            Bag.instance.changes[0].SetActive(true);
            Bag.instance.changes[1].SetActive(true);
            Bag.instance.changes[2].SetActive(true);
        });
        Bag.instance.open = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
    /// <summary>
    /// 每一天开始在每日问候处理完调用
    /// 1.判定概率角色是否出现
    /// 根据相关选项bool值更新npc的行为
    /// </summary>
    public void NewDay()
    {

        Bag.instance.gameObject.SetActive(true);
        Bag.instance.UpdateBag();
        #region home
        //奔走的钟表
        doubleAwarenessDay -= 1;
        if (doubleAwarenessDay == 0)
        {
            doubleAwareness = false;
            clock.SetActive(true);
            clock.transform.localPosition = new Vector3(-0.47f, 1.6f, 0);
        }
        #endregion
        #region 图书馆
        //呢喃的书页
        if (roles[(int)RoleName.Book].show == false)
        {
            int t = Random.Range(1, 3);
            if (t == 2)
            {
                roles[(int)RoleName.Book].show = true;
                roles[(int)RoleName.Book].remain = 2;
                Book.SetActive(true);
            }
        }else{
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
                roles[(int)RoleName.Ink].remain = 2;
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
        #endregion
        #region 角斗场
        //妒火的面具
        if (chooseMask && chooseMaskDay < 3)
        {
            roles[(int)RoleName.Mask].show = true;
            Mask.SetActive(true);
            chooseMask = false;
            chooseMaskDay++;
        }
        else {
            int t = Random.Range(1, 3);
            if (t == 2)
            {
                roles[(int)RoleName.Mask].show = true;
                Mask.SetActive(true);
                chooseMaskDay = 1;
                chooseMask = false;
            }
            else
            {
                roles[(int)RoleName.Mask].show = false;
                Mask.SetActive(false);
                chooseMask = false;
            }
        }
        //叹息之幕
        CrazyFree -= 1; 
        //挑衅的鼓
        if (roles[(int)RoleName.Drum].show == false)
        {
            int t = Random.Range(1, 3);
            if (t == 2)
            {
                roles[(int)RoleName.Drum].show = true;
                roles[(int)RoleName.Drum].remain = 2;
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
        //轮盘每天需要复原
        Roulette.GetComponent<SpriteRenderer>().DOFade(0, 0.1f);
        Roulette.transform.localScale = new Vector3(0,0,0);
        if (Theater.instance)
        {
            Theater.instance.isLunpan = false;
        }
        //荒芜花束,免疫疯狂结束时25%概率出现，每次出现一天
        Flower.SetActive(false);
        if (CrazyFree == 0)
        {
            int t = Random.Range(1, 5);
            if (t == 2)
            {
                roles[(int)RoleName.Flower].show = true;
                Flower.SetActive(true);
                Theater.instance.flowerFirstClick = true;
            }
        }
        //游荡恶语（撕毁2张随机普通牌后出现，每次出现一天）
        BadWord.SetActive(false);
        if(cardDestory %2 ==0 && cardDestory != 0)
        {
            roles[(int)RoleName.BadWord].show = true;
            BadWord.SetActive(true);
            cardDestory = 0;
            Theater.instance.badWordFirstClick = true;
        }
        //希望绝望效果
        if (cards[(int)Card.Hope].number > 0)
        {
            cards[(int)Card.Hope].number -= 1;
        }
        if (cards[(int)Card.Desperate].number > 0)
        {
            cards[(int)Card.Desperate].number -= 1;
        }
        #endregion
        #region 工坊   
        creation2_creativity -= 1;
        #endregion
        EnableAll();
    }
    public int[] crazy = new int[1500];
    public GameObject lunPan;
    public bool enable = false;
    public void EnableAll()
    {
        enable = true;
        
    }
    public void DisableAll()
    {
        enable = false;
       
    }
    public void Restart()
    {
        UII.SetActive(false);
        meun.SetActive(true);
        mainMap.SetActive(false);
        lib.SetActive(false);
        the.SetActive(false);
        res.SetActive(false);
        home.SetActive(false);
        garden.SetActive(false);
        bridge.SetActive(false);
        trade.SetActive(false);
    }
    public GameObject meun;
    public void Exit()
    {

            #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
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