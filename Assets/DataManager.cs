using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    private void Awake()
    {
        instance = this;
    }
    #region 游戏状态
    private bool needGuide;
    public bool NeedGuide
    {
        get { return needGuide;}
        set { needGuide= value; }
    }
    /// <summary>
    /// 退出时是否还处于hello状态
    /// </summary>
    private bool needHello;
    public bool NeedHello
    {
        get { return needHello; }
        set { needHello = value;}
    }
    #endregion
    //玩家状态
    private int life;
    private int workPoint;
    public int Life{
        get { return life; }
        set { life = value; }
        }
    public int WorkPoint
    {
        get { return workPoint; }
        set { workPoint = value;}
    }
    #region 卡牌数量
    public void SaveCard()
    {
       
        for(int i = 0; i < GameManager.instance.cards.Length; i++)
        {
            PlayerPrefs.SetInt(((Card)i).ToString(),GameManager.instance.cards[i].number);
        }
        
    }
    public void LoadCard()
    {
        for (int i = 0; i < GameManager.instance.cards.Length; i++)
        {
          GameManager.instance.cards[i].number =  PlayerPrefs.GetInt(((Card)i).ToString(),0);
        
        }
    }
    #endregion
    #region 可能出现的物品状态
    public void SaveRole()
    {
        for(int i = 0; i < GameManager.instance.roles.Length; i++)
        {
            int t = 0;
            if (GameManager.instance.roles[i].show)
                t = 1;
            PlayerPrefs.SetString(((RoleName)i).ToString(), t.ToString()+" "+ GameManager.instance.roles[i].remain);
        }
    }
    public void LoadRole()
    {
        for(int i = 0; i < GameManager.instance.roles.Length; i++)
        {
            string t = PlayerPrefs.GetString(((RoleName)i).ToString(), "?");
            GameManager.instance.roles[i].remain = int.Parse( t.Split(" ")[1]);
            if (t.Split(" ")[0] == "0")
                GameManager.instance.roles[i].show = false;
            else
                GameManager.instance.roles[i].show = true;

        }
    }
    #endregion
    //场景相关状态
    #region home
    /// <summary>
    /// 是否双倍，注意，按其就可以判断，不需要doubleAwareness了
    /// </summary>
    private int doubleAwarenessDay;
    /// <summary>
    /// 注意，和painted是一个意思，记得把painted删了
    /// </summary>
    private bool getMoney;
    public int DoubleAwarenessDay
    {
        get { return doubleAwarenessDay;}
        set { doubleAwarenessDay = value;}
    }
    public bool GetMoney
    {
        get { return getMoney; }
        set { getMoney = value; }
    }
    #endregion
    #region lib
    /// <summary>
    /// 是否和图书馆里的钢笔交谈
    /// </summary>
    private bool chatedWithPen;
    public bool ChatedWithPen
    {
        get { return chatedWithPen;}
        set { chatedWithPen = value;}
    }
    #endregion
    #region 剧场
    private bool chooseMask;
    public bool ChooseMask
    {
        get { return chooseMask;}
        set { chooseMask = value;}
    }
    private int chooseMaskDay;
    public int ChooseMaskDay
    {
        get { return chooseMaskDay;}
        set { chooseMaskDay = value;}
    }
    private int crazyFree;
    public int CrazyFree
    {
        get { return crazyFree; }
        set { crazyFree = value;}
    }
    private int cardDestroy;
    public int CardDestroy
    {
        get { return cardDestroy;}
        set { cardDestroy = value;}
    }
    /// <summary>
    /// 是否召唤出轮盘
    /// </summary>
    private bool isLunpan;
    public bool IsLunpan
    {
        get { return isLunpan;}
        set { isLunpan = value; }
    }
    private int win;
    public int Win
    {
        get { return win; }
        set { win = value;}
    }
    private bool flowerFirstClick;
    private bool bwFirstClick;
    public bool FlowerFirstClick
    {
        get { return flowerFirstClick;}
        set { flowerFirstClick = value; }
    }
    public bool BWFirstClick
    {
        set { bwFirstClick =value;}
        get { return bwFirstClick;}
    }
    #endregion
    #region 工坊
    private bool creation_creativity;
    public bool Creation_creativity
    {
        get { return creation_creativity; }
        set { creation_creativity = value;}
    }
    private int creation2_creativity;
    public int Creation2_creativity
    {
        get { return creation2_creativity;}
        set { creation2_creativity = value;}
    }
    private bool getInf;
    public bool outScene=false;
    /// <summary>
    /// 世界树到底显示哪个
    /// </summary>
    public bool GetInf
    {
        get { return getInf; }
        set { getInf = value;}
    }
    #endregion
    #region bridge
    private int bridgeCharacter = 0;    
    /// <summary>
    /// 记录现在在桥上的角色是谁,不用在改变时存档，随着workPoint减少一起存
    /// </summary>
    public int BridgeCharacter
    {
        get { return bridgeCharacter; }
        set { bridgeCharacter = value;}
    }
    #endregion
    public string time;
    /// <summary>
    /// 只在对应的游戏节点存档
    /// </summary>
    public void SaveGame()
    {
        Debug.Log("save");
        PlayerPrefs.SetString("time", Time.time.ToString());
        #region 游戏状态
        PlayerPrefs.SetInt("needGuide", needGuide ? 1 : 0);
        PlayerPrefs.SetInt("needHello", needHello ? 1 : 0);
        #endregion
        #region 玩家状态
        PlayerPrefs.SetInt("life", life);
        PlayerPrefs.SetInt("workPoint", workPoint);
        #endregion
        #region 卡牌数量
        SaveCard();
        #endregion
        #region 可能出现的物品状态
        SaveRole();
        #endregion
        //场景相关状态
        #region home
        PlayerPrefs.SetInt("doubleAwarenessDay", doubleAwarenessDay);
        PlayerPrefs.SetInt("getMoney", getMoney?1:0);
        #endregion
        #region lib
        PlayerPrefs.SetInt("chatedWithPen", chatedWithPen?1:0);
 
        #endregion
        #region 剧场
        PlayerPrefs.SetInt("chooseMask",chooseMask?1:0);
        PlayerPrefs.SetInt("chooseMaskDay",chooseMaskDay);
        PlayerPrefs.SetInt("isLunpan", isLunpan?1:0);
        PlayerPrefs.SetInt("win", win);

        PlayerPrefs.SetInt("bwFirstClick", bwFirstClick?1:0);
        PlayerPrefs.SetInt("flowerFirstClick", flowerFirstClick?1:0);
        PlayerPrefs.SetInt("crazyFree", crazyFree);
        PlayerPrefs.SetInt("cardDestroy", cardDestroy);
        #endregion
        #region 工坊
        PlayerPrefs.SetInt("creation_creativity", creation_creativity?1:0);
        PlayerPrefs.SetInt("creation2_creativity", creation2_creativity);
        PlayerPrefs.SetInt("getInf", getInf?1:0);

        #endregion
        #region bridge
        PlayerPrefs.SetInt("getInf", bridgeCharacter);
    #endregion
}


    /// <summary>
    /// 当用户选择从上次开始的时候加载
    /// </summary>
    public void LoadGame()
    {
        time = PlayerPrefs.GetString("time", "");
        #region 游戏状态
        needGuide = PlayerPrefs.GetInt("needGuide", 1)==1?true:false;
        needHello =  PlayerPrefs.GetInt("needHello", 1)==1?true:false;
        #endregion
        #region 玩家状态
        life =  PlayerPrefs.GetInt("life", 7);
        workPoint = PlayerPrefs.GetInt("workPoint", 3);
        Debug.Log(life);
        Debug.Log(workPoint);
        #endregion
        #region 卡牌数量
        LoadCard();
        #endregion
        #region 可能出现的物品状态
        LoadRole();
        #endregion
        //场景相关状态
        #region home
        doubleAwarenessDay = PlayerPrefs.GetInt("doubleAwarenessDay", doubleAwarenessDay);
        getMoney =  PlayerPrefs.GetInt("getMoney", 0)==1?true:false;
        #endregion
        #region lib
        chatedWithPen =  PlayerPrefs.GetInt("chatedWithPen", 0) == 1 ? true : false;

        #endregion
        #region 剧场
        chooseMask = PlayerPrefs.GetInt("chooseMask",0) == 1 ? true : false;
        chooseMaskDay = PlayerPrefs.GetInt("chooseMaskDay", chooseMaskDay);
        isLunpan = PlayerPrefs.GetInt("isLunpan",0) == 1 ? true : false;
        win = PlayerPrefs.GetInt("win",0);
        crazyFree = PlayerPrefs.GetInt("crazyFree", 0);
        cardDestroy = PlayerPrefs.GetInt("cardDestroy", 0);
        bwFirstClick = PlayerPrefs.GetInt("bwFirstClick", 1) == 1 ? true : false;
        flowerFirstClick = PlayerPrefs.GetInt("flowerFirstClick", 1) == 1 ? true : false;
        #endregion
        #region 工坊
        creation_creativity = PlayerPrefs.GetInt("creation_creativity",0) == 1 ? true : false;
        creation2_creativity = PlayerPrefs.GetInt("creation2_creativity", creation2_creativity);
        GetInf = PlayerPrefs.GetInt("getInf",0) == 1 ? true : false;

        #endregion
        #region bridge
        bridgeCharacter = PlayerPrefs.GetInt("getInf", bridgeCharacter);
        #endregion
    }


    private void Start()
    {
     //  PlayerPrefs.SetString("time", "");
    }
}
