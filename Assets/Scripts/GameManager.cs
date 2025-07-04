using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{   public static GameManager instance;
    public GameObject[] workPoints;
    public GameObject[] lifes;
    public CardItem[] cards = new CardItem[22];
    public Role[] roles = new Role[11];
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
    //�������Ƿ��л�
    public GameObject canvasEmpty;
    public GameObject canvasNot;

    public bool TanChuangZhuangTai = false;
    public bool end = false;
    void Awake()
    {
        instance = this;
    }
    public GameObject beginAni;
    /// <summary>
    /// �û�ѡ����Ͼ���Ϸ��ʼ
    /// ������Ϣ
    /// </summary>
    public void StartFromLast()
    {
        //������init��ԭ���ǹر�ҳ�浯��֮���
        Init();
        DataManager.instance.LoadGame();
        VoiceManager.instance.StopMain();
        if(DataManager.instance.time=="")
        {
            beginAni.SetActive(true);
            return;
        }
        if (DataManager.instance.NeedGuide)
        {
            Work();
            Life();
            beginAni.SetActive(true);
            return;
        } 
        VoiceManager.instance.PlayMain();
        if (DataManager.instance.NeedHello)
        {
            Work();
            Life();
            SolveDayHello();
            return;
        }
        Work();
        Life();
        Bag.instance.gameObject.SetActive(true);
        Bag.instance.gameObject.transform .position= new Vector3(9.05f, -0.3f, -1.6f);
        UII.SetActive(true);
        #region home
        //���ߵ��ӱ�
        if (DataManager.instance.DoubleAwarenessDay == 0)
        {
            clock.SetActive(true);
            clock.GetComponent<SpriteRenderer>().DOFade(1, 0.1f);
            clock.transform.localPosition = new Vector3(-0.47f, 1.6f, 0);
        }
        else
        {
            clock.GetComponent<SpriteRenderer>().DOFade(0, 0.1f);
            clock.transform.localPosition = new Vector3(-2.85f, 1.6f, 0);
        }
        //����
        if (DataManager.instance.GetMoney)
        {
            canvasEmpty.SetActive(false);
            canvasNot.SetActive(true);
        }
        else
        {
            canvasEmpty.SetActive(true);
            canvasNot.SetActive(false);
        }
        #endregion
        #region ͼ���
        //��૵���ҳ
        if (roles[(int)RoleName.Book].show)
        {
                Book.SetActive(true);
        }
        else
        { 
                Book.SetActive(false);
        }
        //������īˮƿ
        if (roles[(int)RoleName.InkRole].show == false)
        {
                Ink.SetActive(false);
        }
        else
        {
                Ink.SetActive(true);   
        }
        if (DataManager.instance.ChatedWithPen)
        {
            PenInLib.SetActive(false);
            PenInThe.SetActive(true);
        }
        else
        {
            PenInLib.transform.localPosition = new Vector3(4.08f,3.67f,0);
            PenInLib.SetActive(true);
            PenInThe.SetActive(false);
        }
        #endregion
        #region �Ƕ���
        //�ʻ�����
        if (roles[(int)RoleName.Mask].show == true)
        {
            Mask.SetActive(true);
        }
        else
        {
            Mask.SetActive(false);
        }
        //���ƵĹ�
        if (roles[(int)RoleName.Drum].show == true)
        {
                Drum.SetActive(true);   
        }
        else
        {
                Drum.SetActive(false);   
        }
        //����ÿ����Ҫ��ԭ
        if (DataManager.instance.IsLunpan)
        {
            Roulette.GetComponent<SpriteRenderer>().DOFade(1, 1);
            Roulette.transform.localScale =  new Vector3(0.41f, 0.41f, 0.41f);
        }
        else
        {
            Roulette.GetComponent<SpriteRenderer>().DOFade(0, 0.1f);
            Roulette.transform.localScale = new Vector3(0, 0, 0);
        }
        //���߻���,���߷�����ʱ25%���ʳ��֣�ÿ�γ���һ��
        if (roles[(int)RoleName.Flower].show == true)
        {
            Flower.SetActive(true);
        }
        else
        {
            Flower.SetActive(false);
        }
        if(roles[(int)RoleName.BadWord].show == true)
        {
            BadWord.SetActive(true);
        }
        else
        {
            BadWord.SetActive(false);
        }
        #endregion
        #region ����   
        if(DataManager.instance.Creation2_creativity>0)
            DataManager.instance.outScene = true;
        else
            DataManager.instance.outScene = false;
        #endregion
        EnableAll();
    }
    public void AddLife(int n)
    {
        DataManager.instance.Life += n;
        if (DataManager.instance.Life > 7)
            DataManager.instance.Life = 7;
        for(int i = 0; i < lifes.Length; i++){
            lifes[i].SetActive(false);
        }
        lifes[DataManager.instance.Life - 1].SetActive(true);
    }
    public void Life()
    {
        for (int i = 0; i < lifes.Length; i++)
        {
            lifes[i].SetActive(false);
        }
        if(DataManager.instance.Life > 0)
            lifes[DataManager.instance.Life - 1].SetActive(true);
    }
    public void Work()
    {
        for (int i = 0; i < workPoints.Length; i++)
        {
            workPoints[i].SetActive(false);
        }
        if(DataManager.instance.WorkPoint>0)
            workPoints[DataManager.instance.WorkPoint - 1].SetActive(true);
    }
    public GameObject UII;
    /// <summary>
    /// �ڵ��UI��һ�죬������û��������ʱ����
    /// </summary>
    public void NextDay()
    {
        if (TanChuangZhuangTai)
            return;
        DataManager.instance.WorkPoint = 3;
        DataManager.instance.Life -= 1;
        DataManager.instance.NeedHello = true;
        DataManager.instance.SaveGame();
        Debug.Log(DataManager.instance.NeedHello);
        if (DataManager.instance.Life == 0)
        {
            noLife.SetActive(true);
        }
        else
        {
            Work();
            Life();
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
        DataManager.instance.WorkPoint = 3;
        DataManager.instance.Life -= 1;
        DataManager.instance.NeedHello = true;
        DataManager.instance.SaveGame();
        if (DataManager.instance.Life == 0)
        {
            noLife.SetActive(true);
        }
        else
        {
            Work();
            Life();
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
    /// �ڲ����궯��֮�󴥷�
    /// ��ʼһ������Ϸ�ĳ�ʼ��
    /// </summary>
    public void Init()
    {
        DisableAll();
        UII.SetActive(false);
        //ˢ�������ͱ���
        DataManager.instance.WorkPoint = 3;
        Work();
        DataManager.instance.Life = 7;
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
        DataManager.instance.DoubleAwarenessDay = 0;
        DataManager.instance.GetMoney = false;
        clock.SetActive(true);
        clock.GetComponent<SpriteRenderer>().DOFade(1, 0.1f);
        clock.transform.localPosition = new Vector3(-0.47f, 1.6f, 0);
        canvasEmpty.SetActive(true);
        canvasNot.SetActive(false);
        #endregion
        #region lib
        Book.SetActive(false);
        roles[(int)RoleName.Book].show = false;
        roles[(int)RoleName.Book].remain = 0;
        Ink.SetActive(false);
        roles[(int)RoleName.InkRole].show = false;
        roles[(int)RoleName.InkRole].remain = 0;
        PenInLib.SetActive(true);
        PenInLib.transform.localPosition = new Vector3(4.08f, 3.67f, 0);
        PenInThe.SetActive(false);
        #endregion
        #region �糡
        Mask.SetActive(false);
        roles[(int)RoleName.Mask].show = false;
        roles[(int)RoleName.Mask].remain = 0;
        DataManager.instance.ChooseMask  = false;
        DataManager.instance.CrazyFree = 0;
        for (int i = 0; i < crazy.Length; i++)
        {
            crazy[i] = 0;
        }

        Drum.SetActive(false);
        roles[(int)RoleName.Drum].show = false;
        roles[(int)RoleName.Drum].remain = 0;

        Roulette.GetComponent<SpriteRenderer>().DOFade(0, 0.1f);
        Roulette.transform.localScale = new Vector3(0,0,0);
        DataManager.instance.IsLunpan = false;

        Flower.SetActive(false);
        roles[(int)RoleName.Flower].show = false;
        roles[(int)RoleName.Flower].remain = 0;

        BadWord.SetActive(false);
        roles[(int)RoleName.BadWord].show = false;
        roles[(int)RoleName.BadWord].remain = 0;
        #endregion
        #region ����
        DataManager.instance.Creation_creativity = false;
        DataManager.instance.Creation2_creativity = 0;

        treeAwake.SetActive(false);
        treeDie.SetActive(true);
        DataManager.instance.GetInf = false;
        #endregion
        #region Bridge
        if(DataManager.instance)
            DataManager.instance.BridgeCharacter = 0;
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
    /// ���º󱣴���Ϸ
    /// </summary>
    public void SubWorkPoint()
    {
        DataManager.instance.WorkPoint -= 1;
        Work();
        DataManager.instance.SaveGame();
        if (DataManager.instance.WorkPoint == 0)
        {
           noWorkPoint.SetActive(true);
        }
    }
    /// <summary>
    /// ��ʼ�ж�Ҫ������Щÿ���ʺ��ڿ�ʼʱ������Ϸ����
    /// </summary>
    public void SolveDayHello()
    {
        DataManager.instance.SaveGame();
        Bag.instance.UpdateBag();
        DisableAll();
        Bag.instance.gameObject.SetActive(false);
        //��
        if (DataManager.instance.DoubleAwarenessDay>0)
        { 
               
                if (DataManager.instance.DoubleAwarenessDay == 1)
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
        if (DataManager.instance.Creation2_creativity == 1)
        {
            if (cards[(int)Card.Hope].number > 0)
                hellos.Add(Sholve5); 
            hellos.Add(Sholve5);
            if (cards[(int)Card.Desperate].number > 0)
                hellos.RemoveAt(hellos.Count - 1);  
        }
        else if (DataManager.instance.Creation2_creativity > 0)
        {
            if (cards[(int)Card.Hope].number > 0)
                hellos.Add(Sholve1_4);
            hellos.Add(Sholve1_4);
            if (cards[(int)Card.Desperate].number > 0)
                hellos.RemoveAt(hellos.Count - 1);
        }
        else if (DataManager.instance.Creation_creativity)
        {
            if (cards[(int)Card.Hope].number > 0)
                hellos.Add(Sholve1);
            hellos.Add(Sholve1);
            if (cards[(int)Card.Desperate].number > 0)
                hellos.RemoveAt(hellos.Count - 1);
        }
        //����
        if (DataManager.instance.GetMoney)
        {
            if (cards[(int)Card.Hope].number > 0)
                hellos.Add(canvas);   
            hellos.Add(canvas);
            if (cards[(int)Card.Desperate].number > 0)
                hellos.RemoveAt(hellos.Count - 1);
            
        }
   
        //������
        if (DataManager.instance.GetInf)
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
    /// 4.����ʱ������Ϸ
    /// </summary>
    public void NewDay()
    {
        DataManager.instance.NeedHello = false;
        Bag.instance.gameObject.SetActive(true);
        Bag.instance.UpdateBag();
        Bag.instance.detect = false;
        UII.SetActive(true);
        #region home
        //���ߵ��ӱ�
        DataManager.instance.DoubleAwarenessDay -= 1;
        if (DataManager.instance.DoubleAwarenessDay == 0)
        {
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
        if (roles[(int)RoleName.InkRole].show == false)
        {
            int t = Random.Range(1, 3);
            if (t == 2)
            {
                roles[(int)RoleName.InkRole].show = true;
                roles[(int)RoleName.InkRole].remain = 2;
                Ink.SetActive(true);
            }
        }
        else
        {
            roles[(int)RoleName.InkRole].remain -= 1;
            if (roles[(int)RoleName.InkRole].remain == 0)
            {
                roles[(int)RoleName.InkRole].show = false;
                Ink.SetActive(false);
            }
        }
        #endregion
        #region �Ƕ���
        //�ʻ�����
        if (DataManager.instance.ChooseMask && DataManager.instance.ChooseMaskDay < 3)
        {
            roles[(int)RoleName.Mask].show = true;
            Mask.SetActive(true);
            DataManager.instance.ChooseMask = false;
            DataManager.instance.ChooseMaskDay++;
        }
        else {
            int t = Random.Range(1, 3);
            if (t == 2)
            {
                roles[(int)RoleName.Mask].show = true;
                Mask.SetActive(true);
                DataManager.instance.ChooseMaskDay = 1;
                DataManager.instance.ChooseMask = false;
            }
            else
            {
                roles[(int)RoleName.Mask].show = false;
                Mask.SetActive(false);
                DataManager.instance.ChooseMask = false;
            }
        }
        //̾Ϣ֮Ļ
        DataManager.instance.CrazyFree -= 1;
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
        DataManager.instance.IsLunpan = false;
        //���߻���,���߷�����ʱ25%���ʳ��֣�ÿ�γ���һ��
        Flower.SetActive(false);
        if (DataManager.instance.CrazyFree == 0)
        {
            int t = Random.Range(1, 5);
            if (t == 2)
            {
                roles[(int)RoleName.Flower].show = true;
                Flower.SetActive(true);
                DataManager.instance.FlowerFirstClick = true;
            }
        }
        //�ε����˺��2�������ͨ�ƺ���֣�ÿ�γ���һ�죩
        BadWord.SetActive(false);
        if(DataManager.instance.CardDestroy %2 ==0 && DataManager.instance.CardDestroy!= 0)
        {
            roles[(int)RoleName.BadWord].show = true;
            BadWord.SetActive(true);
            DataManager.instance.CardDestroy = 0;
            DataManager.instance.BWFirstClick = true;
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
        DataManager.instance.Creation2_creativity -= 1;
        if (DataManager.instance.Creation2_creativity < 0)
            DataManager.instance.Creation2_creativity = 0;
        if (DataManager.instance.Creation2_creativity > 0)
            DataManager.instance.outScene = true;
        else
        {
            DataManager.instance.outScene = false;
        }
        #endregion
        EnableAll(); 
        DataManager.instance.SaveGame();
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
    InkRole,
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