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
    //�Ƿ�ÿ�ղ���2�ž���
    public bool doubleAwareness = false;
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
    /// �����ж�ֵ������Ƿ������һ��
    /// </summary>
    public void SubWorkPoint()
    {
        workPoint -= 1;
        workPointText.text = workPoint.ToString();
        if(workPoint == 0)
        {
            //����������־������һ��
        }
    }

    /// <summary>
    /// ÿһ�쿪ʼʱ����
    /// 1.��������������¿���
    /// 2.�ж����ʽ�ɫ�Ƿ����
    /// </summary>
    public void NewDay()
    {



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