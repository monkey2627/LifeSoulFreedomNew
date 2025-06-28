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
    //���ʳ��ֵĵ���
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
    /// �����ж�ֵ������Ƿ������һ��
    /// </summary>
    public void SubWorkPoint()
    {
        workPoint -= 1;
        workPointText.text = workPoint.ToString();
        if(workPoint == 0)
        {
            //ˢ����������
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
        //��һ��һ������ÿ���ʺ򣬼���hellos
        //��
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
        //԰�ղ���
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
    /// <summary>
    /// ÿһ�쿪ʼ��ÿ���ʺ��������
    /// 1.��������������¿���
    /// 2.�ж����ʽ�ɫ�Ƿ����
    /// </summary>
    public void NewDay()
    {
        Bag.instance.gameObject.SetActive(true);
        //��૵���ҳ
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
        //������īˮƿ
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
        //�ʻ�����
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
        //���ƵĹ�
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
        //���߻���,���߷�����ʱ25%���ʳ��֣�ÿ�γ���һ��
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
        
        //�ε����˺��2�������ͨ�ƺ���֣�ÿ�γ���һ�죩
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