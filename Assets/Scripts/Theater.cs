using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theater : MonoBehaviour
{
    public GameObject pen;
    public GameObject mask;
    public GameObject drum;
    public GameObject flower;
    public GameObject badWords;
    public GameObject lunPan;
    public GameObject tanxi;
    int find()
    {
        while (true)
        {
            int t = Random.Range(0, 20);
            if(GameManager.instance.cards[t].number > 0)
            {
                return t;
            }
        }
    }
    //妒火的面具
    /// <summary>
    /// 消耗一点行动点，获得一份疯狂，积攒3份疯狂会撕毁一张随机普通牌
    /// </summary>
    public void Mask1()
    {
        GameManager.instance.chooseMask = true;
        GameManager.instance.cards[(int)Card.Crazy].number += 1;
        if(GameManager.instance.cards[(int)Card.Crazy].number == 3)
        {
            //不免疫
            if (GameManager.instance.CrazyFree <= 0)
            {
                //todo 随机撕毁一张普通牌
                int card = find();
            }
        }
        //todo 此处在提示撕毁之后再转到下一天
       // GameManager.instance.SubWorkPoint();
    }
    //叹息之幕（常驻)
    public void Tanxi1()
    {
        //todo 观看自己的疯狂
        if(GameManager.instance.cards[(int)Card.Crazy].number >= 1) {
            GameManager.instance.cards[(int)Card.Crazy].number -= 1;
            GameManager.instance.cards[(int)Card.Awakeness].number += 1;
            if(GameManager.instance.cards[(int)Card.Awakeness].number == 3)
            {
                GameManager.instance.CrazyFree = 4;
            }

        }
    }
    public void Tanxi2()
    {
        if (GameManager.instance.cards[(int)Card.Crazy].number >= 6)
        {
            GameManager.instance.cards[(int)Card.Crazy].number -= 6;
            int t = Random.Range(1, 11);
            if (t <=7)
            {
                GameManager.instance.cards[(int)Card.Desire].number += 1;
            }
            else
            {
                GameManager.instance.cards[(int)Card.Luck].number += 1;
            }
        }
    }
    //挑衅的鼓
    /// <summary>
    /// 消耗一点行动点，用1份疯狂和1份觉悟召唤一次激情的轮盘
    /// </summary>
    public void Gu()
    {
          GameManager.instance.cards[(int)Card.Crazy].number -= 1;
          GameManager.instance.cards[(int)Card.Awareness].number -= 1;
        //todo 出现激情的轮盘的动画，出现完了之后GameManager.instance.SubWorkPoint();


    }
    //激情的轮盘
    /// <summary>
    /// 不消耗行动点，与挑衅的鼓进行轮盘内的石头剪刀布（轮盘的数字换成石头剪刀布），
    /// 胜利后获得3金钱，失败则获得1疯狂。连续胜利3次后获得一张争斗
    /// </summary>
    public void Roulette()
    {
        //出现轮盘，开始石头剪刀布
        startGame = true;
    }
    bool startGame = false;
    public GameObject[] sjb;
    //充满决心的圆珠笔（常驻)
    public GameObject penOption;
    public GameObject penDes;
    public void ClickPen()
    {
       pen.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            pen.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                pen.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    pen.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        penOption.SetActive(true);
        penDes.SetActive(true);
    }
    /// <summary>
    /// 消耗一点行动点，使用一张觉悟获得信息和1金钱，可能（10%）获得争斗
    /// </summary>
    public void Pen1()
    {
        GameManager.instance.cards[(int)Card.Information].number += 1;
        GameManager.instance.cards[(int)Card.Money].number += 1;
        int t = Random.Range(1, 11);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Fight].number += 1;
        }
        GameManager.instance.SubWorkPoint();
        Bag.instance.UpdateBag();
    }
    /// <summary>
    /// 消耗一点行动点，使用2张任意普通牌获得一张争斗或一张合作
    /// </summary>
    public void Pen2()
    {
        int t = Random.Range(1, 3);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Fight].number += 1;
        }
        else
        {
            GameManager.instance.cards[(int)Card.Cooperation].number += 1;
        }
        GameManager.instance.SubWorkPoint();
        Bag.instance.UpdateBag();
    }
    //荒芜花束
    /// <summary>
    /// 不消耗行动点，获得一张幸运/希望（接下来3天收益+1）（80%/20%）
    /// </summary>
    public void Flower()
    {
        int t = Random.Range(1, 6);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Hope].number += 3;
        }
        else
        {
            GameManager.instance.cards[(int)Card.Luck].number += 1;
        }
    }
    /// <summary>
    /// 游荡恶语（撕毁2张随机普通牌后出现，每次出现一天）：
    /// 不消耗行动点，获得一张争斗/绝望（接下来3天收益-1）（50%/50%）
    /// </summary>
    public void BadWord()
    {
        int t = Random.Range(1, 3);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Desperate].number += 3;
        }
        else
        {
            GameManager.instance.cards[(int)Card.Fight].number += 1;
        }
    }
    public GameObject mainMap;
    public void Back()
    {
        gameObject.SetActive(false);
        mainMap.SetActive(true);
        Bag.instance.detect = false;
    }
}
