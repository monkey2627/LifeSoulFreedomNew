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
    //�Ƿ�ÿ�ղ���2�ž���
    public bool doubleAwareness = false;
    public int doubleAwarenessDay = 0;
    //�Ƿ�ÿ�ջ��һ�ݽ�Ǯ
    public bool getMoney = false;
    //���߷���ʣ������
    public int CrazyFree = 0;
    //�Ƿ�ÿ�ղ���һ�������һ�Ŵ���
    public bool creation_creativity = false;
    //����2���������һ�Ŵ����ʱ��
    public int creation2_creativity = 0;
    //�Ƿ�ÿ�ջ��һ����Ϣ
    public bool getInf = false;
    //�����Ƿ�ѡ��ʻ����ߣ�ÿ��һ�����
    public bool chooseMask = false;
    //˺�ٵĿ�����
    public int cardDestory = 0;
    int chooseMaskDay = 0;
    //��õ���������
    public int awakeNumber = 0;
    //���ʳ��ֵĵ���
    public GameObject Book;
    public GameObject Ink;
    public GameObject Mask;
    public GameObject Drum;
    public GameObject Roulette;
    public GameObject Flower;
    public GameObject BadWord;
    public GameObject treeDie;
    public GameObject treeAwake;
    public GameObject wu;
    public GameObject mirrors;
    public GameObject door;
    //��Ҫ�ص�ԭ�ص�Բ���
    public GameObject PenInLib;
    public GameObject PenInThe;

    public GameObject canvasEmpty;
    public GameObject canvasNot;

    public bool TanChuangZhuangTai = false;
    public bool end = false;
    void Awake()
    {
       // Screen.SetResolution(1920, 1080, true);
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
    /// <summary>
    /// �ڵ��UI��һ�죬������û��������ʱ����
    /// </summary>
    public void NextDay()
    {
        if (TanChuangZhuangTai)
            return;
        //ˢ����������
        workPoint = 3;
        life -= 1;
        if (life == 0)
        {
            noLife.SetActive(true);
        }
        else
        {
            Work();
            Life();
            Debug.Log("next");
            Debug.Log("life" + life);
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
    }
    public void NextDayMust()
    {
        //ˢ����������
        workPoint = 3;
        life -= 1;
        if (life == 0)
        {
            noLife.SetActive(true);
        }
        else
        {
            Work();
            Life();
            Debug.Log("next");
            Debug.Log("life: " + life);
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
    }
    /// <summary>
    /// �ڲ����궯��֮��ᴥ������ʼһ������Ϸ
    /// </summary>
    public void Init()
    {
        DisableAll();
        UII.SetActive(false);
        //ˢ�������ͱ���
        workPoint = 3;
        Work();
        life = 7;
        Life();
        //ˢ�¿���
        for(int i = 0; i < 22; i++)
        {
            cards[i] = new CardItem { card =(Card)i,number = 0};
        }
        cards[(int)Card.Awareness].number = 3;
        //�ѱ������ϣ���������λ��
        Bag.instance.gameObject.SetActive(false);
        Bag.instance.gameObject.transform.position = new Vector3(9.05f, -0.3f, -1.6f);
        Bag.instance.detect = false;
        Bag.instance.isMove = false;
        Bag.instance.open = false;
        //todo �����������״̬����ԭ���г���
        #region home
        doubleAwareness = false;
        doubleAwarenessDay = 0;
        getMoney = false;
        clock.SetActive(true);
        clock.GetComponent<SpriteRenderer>().DOFade(1, 0.1f);
        clock.transform.localPosition = new Vector3(-0.47f, 1.6f, 0);
        canvasEmpty.SetActive(true);
        canvasNot.SetActive(false);
        if (Home.instance)
            Home.instance.painted = false;
        #endregion
        #region lib
        Book.SetActive(false);
        roles[(int)RoleName.Book].show = false;
        roles[(int)RoleName.Book].remain = 0;
        Ink.SetActive(false);
        roles[(int)RoleName.Ink].show = false;
        roles[(int)RoleName.Ink].remain = 0;
        PenInLib.SetActive(true);
        PenInLib.transform.localPosition = new Vector3(4.08f, 3.67f, 0);
        PenInThe.SetActive(false);
        #endregion
        #region �糡
        Mask.SetActive(false);
        roles[(int)RoleName.Mask].show = false;
        roles[(int)RoleName.Mask].remain = 0;
        chooseMask = false;

        CrazyFree = 0;
        for (int i = 0; i < crazy.Length; i++)
        {
            crazy[i] = 0;
        }

        Drum.SetActive(false);
        roles[(int)RoleName.Drum].show = false;
        roles[(int)RoleName.Drum].remain = 0;

        Roulette.GetComponent<SpriteRenderer>().DOFade(0, 0.1f);
        Roulette.transform.localScale = new Vector3(0,0,0);
        if (Theater.instance)
        {
            Theater.instance.isLunpan = false;
        }

        Flower.SetActive(false);
        roles[(int)RoleName.Flower].show = false;
        roles[(int)RoleName.Flower].remain = 0;

        BadWord.SetActive(false);
        roles[(int)RoleName.BadWord].show = false;
        roles[(int)RoleName.BadWord].remain = 0;
        #endregion
        #region ����
        creation_creativity = false;
        creation2_creativity = 0;

        treeAwake.SetActive(false);
        treeDie.SetActive(true);
        getInf = false;
        #endregion
        #region Bridge
        wu.SetActive(true);
        mirrors.SetActive(false);
        door.SetActive(false);
        #endregion
        //todo �ص����е���
        ClockDay1.SetActive(false); 
        ClockDay1_4.SetActive(false);
        ClockDay5.SetActive(false);
        Sholve1.SetActive(false);
        Sholve1_4.SetActive(false);
        Sholve5.SetActive(false);
        canvas.SetActive(false);
        worldTree.SetActive(false);
        noLife.SetActive(false);
        noWorkPoint.SetActive(false);
       
        if(GetPopup.instance)
            GetPopup.instance.gameObject.SetActive(false);

        UII.SetActive(false);
        mainMap.SetActive(true);
        lib.SetActive(false);
        the.SetActive(false);
        res.SetActive(false);
        home.SetActive(false);
        garden.SetActive(false);
        bridge.SetActive(false);
        trade.SetActive(false);
        
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
    /// �����ж�ֵ������Ƿ������һ��
    /// </summary>
    public void SubWorkPoint()
    {
        workPoint -= 1;
        Work();
        if(workPoint == 0)
        {
           noWorkPoint.SetActive(true);
        }
    }
    public void SolveDayHello()
    {
        Bag.instance.UpdateBag();
        DisableAll();
        Debug.Log("solveHello");
        Bag.instance.gameObject.SetActive(false);
        //��
        
        if (doubleAwareness)
        { 
               
                if (doubleAwarenessDay == 1)
                {
                    if(cards[(int)Card.Hope].number > 0)
                     hellos.Add(ClockDay5);
                    hellos.Add(ClockDay5);
                    if (cards[(int)Card.Desperate].number > 0)
                        hellos.RemoveAt(hellos.Count - 1);
                    
                }
                else
                {
                    if (cards[(int)Card.Hope].number > 0)
                        hellos.Add(ClockDay1_4);
                    hellos.Add(ClockDay1_4);
                    if (cards[(int)Card.Desperate].number > 0)
                        hellos.RemoveAt(hellos.Count - 1);
                }
        }else
        {
            if (cards[(int)Card.Hope].number > 0)
                hellos.Add(ClockDay1);
            hellos.Add(ClockDay1);
            if (cards[(int)Card.Desperate].number > 0)
                hellos.RemoveAt(hellos.Count - 1);
        }
        //԰�ղ���
        if (creation2_creativity == 1)
        {
            if (cards[(int)Card.Hope].number > 0)
                hellos.Add(Sholve5); 
            hellos.Add(Sholve5);
            if (cards[(int)Card.Desperate].number > 0)
                hellos.RemoveAt(hellos.Count - 1);  
        }
        else if (creation2_creativity > 0)
        {
            if (cards[(int)Card.Hope].number > 0)
                hellos.Add(Sholve1_4);
            hellos.Add(Sholve1_4);
            if (cards[(int)Card.Desperate].number > 0)
                hellos.RemoveAt(hellos.Count - 1);
        }
        else if (creation_creativity)
        {
            if (cards[(int)Card.Hope].number > 0)
                hellos.Add(Sholve1);
            hellos.Add(Sholve1);
            if (cards[(int)Card.Desperate].number > 0)
                hellos.RemoveAt(hellos.Count - 1);
        }
        //����
        if (getMoney)
        {
            if (cards[(int)Card.Hope].number > 0)
                hellos.Add(canvas);   
            hellos.Add(canvas);
            if (cards[(int)Card.Desperate].number > 0)
                hellos.RemoveAt(hellos.Count - 1);
            
        }
   
        //������
        if (getInf)
        {
            if (cards[(int)Card.Hope].number > 0)
                hellos.Add(worldTree);
            hellos.Add(worldTree);
            if (cards[(int)Card.Desperate].number > 0)
                hellos.RemoveAt(hellos.Count - 1);
        }
        //��ÿ���ʺ��
        if (hellos.Count > 0)
        {
            hellos[0].SetActive(true);
            hellos.RemoveAt(0);
        }
        else
        {
            NewDay();
        }
        

    }
    public GameObject clock;
  
    //ÿ�ΰ�������Ҫÿ���ʺ�Ķ����ӽ�ȥ����˳����
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
            //ÿ���ʺ�������
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
        if (Input.GetMouseButtonDown(0))
        {
            if (end)
            {
                Restart();
            }
        }
    }
    /// <summary>
    /// ÿһ�쿪ʼ��ÿ���ʺ��������
    /// 1.�ж����ʽ�ɫ�Ƿ����
    /// 2.�������ѡ��boolֵ����npc����Ϊ
    /// 3.�������г���
    /// </summary>
    public void NewDay()
    {

        Bag.instance.gameObject.SetActive(true);
        Bag.instance.UpdateBag();
        Bag.instance.detect = false;
        #region home
        //���ߵ��ӱ�
        doubleAwarenessDay -= 1;
        if (doubleAwarenessDay == 0)
        {
            doubleAwareness = false;
            clock.SetActive(true);
            clock.GetComponent<SpriteRenderer>().DOFade(1, 0.1f);
            clock.transform.localPosition = new Vector3(-0.47f, 1.6f, 0);
        }
        #endregion
        #region ͼ���
        //��૵���ҳ
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
        //������īˮƿ
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
        #region �Ƕ���
        //�ʻ�����
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
        //̾Ϣ֮Ļ
        CrazyFree -= 1; 
        //���ƵĹ�
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
        //����ÿ����Ҫ��ԭ
        Roulette.GetComponent<SpriteRenderer>().DOFade(0, 0.1f);
        Roulette.transform.localScale = new Vector3(0,0,0);
        if (Theater.instance)
        {
            Theater.instance.isLunpan = false;
        }
        //���߻���,���߷�����ʱ25%���ʳ��֣�ÿ�γ���һ��
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
        //�ε����˺��2�������ͨ�ƺ���֣�ÿ�γ���һ�죩
        BadWord.SetActive(false);
        if(cardDestory %2 ==0 && cardDestory != 0)
        {
            roles[(int)RoleName.BadWord].show = true;
            BadWord.SetActive(true);
            cardDestory = 0;
            Theater.instance.badWordFirstClick = true;
        }
        //ϣ������Ч��
        if (cards[(int)Card.Hope].number > 0)
        {
            cards[(int)Card.Hope].number -= 1;
        }
        if (cards[(int)Card.Desperate].number > 0)
        {
            cards[(int)Card.Desperate].number -= 1;
        }
        #endregion
        #region ����   
        creation2_creativity -= 1;
        if (WorkShop.instance)
            WorkShop.instance.outScene = false;
        #endregion
        EnableAll();
    }
    public int[] crazy = new int[1500];
    public bool enable = false;
    public void EnableAll()
    {
        enable = true;
        
    }
    public void DisableAll()
    {
        enable = false;
       
    }
    public GameObject endPanel;
    /// <summary>
    /// ����ֵ���㣬���¿�ʼ����ʾmeun
    /// </summary>
    public void Restart()
    {
        meun.SetActive(true);
        endPanel.SetActive(false);
        VoiceManager.instance.StopMain();
        //todo �ص����е���
        ClockDay1.SetActive(false);
        ClockDay1_4.SetActive(false);
        ClockDay5.SetActive(false);
        Sholve1.SetActive(false);
        Sholve1_4.SetActive(false);
        Sholve5.SetActive(false);
        canvas.SetActive(false);
        worldTree.SetActive(false);
        noLife.SetActive(false);
        noWorkPoint.SetActive(false);

        if (GetPopup.instance)
            GetPopup.instance.gameObject.SetActive(false);

        UII.SetActive(false);
        mainMap.SetActive(true);
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
    //��Ӧ�ó��ֵ�����
    public int remain;
    //�����Ƿ�Ӧ�ó���
    public bool show;
}
public enum Card
{
    //��ͨ
    Cooperation,
    Awareness,
    Trade,
    KnowledgeSeek,
    Luck,
    Desire,
    Creativity,
    Fight,
    //��Ʒ
    Money,
    Knowledge,
    Ink,
    Information,
    Story,
    Crazy,
    Awakeness,
    Creation,
    //����
    Life,
    Soul,
    Freedom,
        //
        Hope,
        Desperate
}
public struct CardItem
{
    //��������
    public Card card;
    //��������
    public int number;
}