using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{

    //呢喃的书页
    /// <summary>
    /// 消耗一点行动点，消耗2金钱获得一份知识
    /// </summary>
    public void Book1()
    {
        
            GameManager.instance.cards[(int)Card.Money].number -= 2;
            GameManager.instance.cards[(int)Card.Knowledge].number += 1;
        GameManager.instance.SubWorkPoint();

    }
    /// <summary>
    /// 消耗一点行动点，消耗2金钱和一张觉悟获得一份知识，可能（25%）获得求知
    /// </summary>
    public void Book2()
    {
       
            GameManager.instance.cards[(int)Card.Money].number -= 2;
            GameManager.instance.cards[(int)Card.Awareness].number -= 1;
            GameManager.instance.cards[(int)Card.Knowledge].number += 1;
            int t = Random.Range(1, 5);
            if(t == 2)
            {
              GameManager.instance.cards[(int)Card.KnowledgeSeek].number += 1;
            }
        GameManager.instance.SubWorkPoint();

    }
    /// <summary>
    /// 消耗一点行动点，用3份墨水换取一份信息/求知/幸运（50%/25%/25%）
    /// </summary>
    public void Book3()
    {
       
        GameManager.instance.cards[(int)Card.Ink].number -= 3;
        int t = Random.Range(1, 5);
        if (t == 2 || t == 1)
        {
            GameManager.instance.cards[(int)Card.Information].number += 1;
        }
        else if (t == 3)
        {
            GameManager.instance.cards[(int)Card.KnowledgeSeek].number += 1;
        }
        else if (t == 4)
        {
            GameManager.instance.cards[(int)Card.Luck].number += 1;
        }
        GameManager.instance.SubWorkPoint();

    }
    //哭泣的墨水瓶
    /// <summary>
    /// 消耗一点行动点，用2份知识换取——求知
    /// </summary>
    public void Ink1()
    {
      
            GameManager.instance.cards[(int)Card.Knowledge].number -= 2;
            GameManager.instance.cards[(int)Card.KnowledgeSeek].number += 1;
       
        GameManager.instance.SubWorkPoint();
    }
    /// <summary>
    /// 消耗一点行动点，可能（10%）获得墨水
    /// </summary>
    public void Ink2()
    {
        int t = Random.Range(1, 11);
        if(t == 2)
        {
            GameManager.instance.cards[(int)Card.Ink].number += 1;
        }
        GameManager.instance.SubWorkPoint();
    }
    /// <summary>
    /// 消耗一点行动点，使用一张合作，获得创造/求知（50%/50%）
    /// </summary>
    public void Ink3()
    {
            GameManager.instance.cards[(int)Card.Cooperation].number -= 1;
            int t = Random.Range(1, 3);
            if (t == 2)
            {
                GameManager.instance.cards[(int)Card.Creativity].number += 1;

            }
            else
            {
                GameManager.instance.cards[(int)Card.KnowledgeSeek].number += 1;
            }
        
        GameManager.instance.SubWorkPoint();
    }
    //充满决心的圆珠笔
    public bool firstClick = true;
    public GameObject pen1;
    public GameObject pen2;
    /// <summary>
    /// 首次交流（消耗一点行动点）获得信息，后续该角色迁移至剧场
    /// </summary>
    public void Pen()
    {
        if (firstClick)
        {
            firstClick = false;
            GameManager.instance.cards[(int)Card.Information].number += 1;
            //todo 圆珠笔消失的动画

            pen2.SetActive(true);
        }
        GameManager.instance.SubWorkPoint();
    }
    //缄默的档案柜
    /// <summary>
    /// 消耗一点行动点，获得故事
    /// </summary>
    public void Desk1()
    {
        GameManager.instance.cards[(int)Card.Story].number += 1;
        GameManager.instance.SubWorkPoint();
    }
    
}
