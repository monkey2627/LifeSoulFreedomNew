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
    #region ��Ϸ״̬
    private bool needGuide;
    public bool NeedGuide
    {
        get { return needGuide;}
        set { needGuide= value; }
    }
    /// <summary>
    /// �˳�ʱ�Ƿ񻹴���hello״̬
    /// </summary>
    private bool needHello;
    public bool NeedHello
    {
        get { return needHello; }
        set { needHello = value;}
    }
    #endregion
    //���״̬
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
    #region ��������
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
    #region ���ܳ��ֵ���Ʒ״̬
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
    //�������״̬
    #region home
    /// <summary>
    /// �Ƿ�˫����ע�⣬����Ϳ����жϣ�����ҪdoubleAwareness��
    /// </summary>
    private int doubleAwarenessDay;
    /// <summary>
    /// ע�⣬��painted��һ����˼���ǵð�paintedɾ��
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
    /// �Ƿ��ͼ�����ĸֱʽ�̸
    /// </summary>
    private bool chatedWithPen;
    public bool ChatedWithPen
    {
        get { return chatedWithPen;}
        set { chatedWithPen = value;}
    }
    #endregion
    #region �糡
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
    /// �Ƿ��ٻ�������
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
    #region ����
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
    /// ������������ʾ�ĸ�
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
    /// ��¼���������ϵĽ�ɫ��˭,�����ڸı�ʱ�浵������workPoint����һ���
    /// </summary>
    public int BridgeCharacter
    {
        get { return bridgeCharacter; }
        set { bridgeCharacter = value;}
    }
    #endregion
    public string time;
    /// <summary>
    /// ֻ�ڶ�Ӧ����Ϸ�ڵ�浵
    /// </summary>
    public void SaveGame()
    {
        Debug.Log("save");
        PlayerPrefs.SetString("time", Time.time.ToString());
        #region ��Ϸ״̬
        PlayerPrefs.SetInt("needGuide", needGuide ? 1 : 0);
        PlayerPrefs.SetInt("needHello", needHello ? 1 : 0);
        #endregion
        #region ���״̬
        PlayerPrefs.SetInt("life", life);
        PlayerPrefs.SetInt("workPoint", workPoint);
        #endregion
        #region ��������
        SaveCard();
        #endregion
        #region ���ܳ��ֵ���Ʒ״̬
        SaveRole();
        #endregion
        //�������״̬
        #region home
        PlayerPrefs.SetInt("doubleAwarenessDay", doubleAwarenessDay);
        PlayerPrefs.SetInt("getMoney", getMoney?1:0);
        #endregion
        #region lib
        PlayerPrefs.SetInt("chatedWithPen", chatedWithPen?1:0);
 
        #endregion
        #region �糡
        PlayerPrefs.SetInt("chooseMask",chooseMask?1:0);
        PlayerPrefs.SetInt("chooseMaskDay",chooseMaskDay);
        PlayerPrefs.SetInt("isLunpan", isLunpan?1:0);
        PlayerPrefs.SetInt("win", win);

        PlayerPrefs.SetInt("bwFirstClick", bwFirstClick?1:0);
        PlayerPrefs.SetInt("flowerFirstClick", flowerFirstClick?1:0);
        PlayerPrefs.SetInt("crazyFree", crazyFree);
        PlayerPrefs.SetInt("cardDestroy", cardDestroy);
        #endregion
        #region ����
        PlayerPrefs.SetInt("creation_creativity", creation_creativity?1:0);
        PlayerPrefs.SetInt("creation2_creativity", creation2_creativity);
        PlayerPrefs.SetInt("getInf", getInf?1:0);

        #endregion
        #region bridge
        PlayerPrefs.SetInt("getInf", bridgeCharacter);
    #endregion
}


    /// <summary>
    /// ���û�ѡ����ϴο�ʼ��ʱ�����
    /// </summary>
    public void LoadGame()
    {
        time = PlayerPrefs.GetString("time", "");
        #region ��Ϸ״̬
        needGuide = PlayerPrefs.GetInt("needGuide", 1)==1?true:false;
        needHello =  PlayerPrefs.GetInt("needHello", 1)==1?true:false;
        #endregion
        #region ���״̬
        life =  PlayerPrefs.GetInt("life", 7);
        workPoint = PlayerPrefs.GetInt("workPoint", 3);
        Debug.Log(life);
        Debug.Log(workPoint);
        #endregion
        #region ��������
        LoadCard();
        #endregion
        #region ���ܳ��ֵ���Ʒ״̬
        LoadRole();
        #endregion
        //�������״̬
        #region home
        doubleAwarenessDay = PlayerPrefs.GetInt("doubleAwarenessDay", doubleAwarenessDay);
        getMoney =  PlayerPrefs.GetInt("getMoney", 0)==1?true:false;
        #endregion
        #region lib
        chatedWithPen =  PlayerPrefs.GetInt("chatedWithPen", 0) == 1 ? true : false;

        #endregion
        #region �糡
        chooseMask = PlayerPrefs.GetInt("chooseMask",0) == 1 ? true : false;
        chooseMaskDay = PlayerPrefs.GetInt("chooseMaskDay", chooseMaskDay);
        isLunpan = PlayerPrefs.GetInt("isLunpan",0) == 1 ? true : false;
        win = PlayerPrefs.GetInt("win",0);
        crazyFree = PlayerPrefs.GetInt("crazyFree", 0);
        cardDestroy = PlayerPrefs.GetInt("cardDestroy", 0);
        bwFirstClick = PlayerPrefs.GetInt("bwFirstClick", 1) == 1 ? true : false;
        flowerFirstClick = PlayerPrefs.GetInt("flowerFirstClick", 1) == 1 ? true : false;
        #endregion
        #region ����
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
