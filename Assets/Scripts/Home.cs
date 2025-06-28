using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public GameObject[] texts;
    public int showNumber = 0;
    public GameObject[] options;
    public int optionsNumber = 0;
    //昏黄的台灯
    /// <summary>
    /// 点击选项显示下一个文本
    /// </summary>
    public void Guide()
    {
        texts[showNumber].SetActive(false);
        showNumber++;
        texts[showNumber].SetActive(true);
        StartCoroutine(ShowNext());
    }
    /// <summary>
    /// 延迟三秒后出现下一个选项
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowNext()
    {
        yield return new WaitForSeconds(3);
        if (optionsNumber > 0)
        {
            options[optionsNumber-1].SetActive(false);
        }
        options[optionsNumber].SetActive(true);
        //todo 出现选项框
        optionsNumber++;
    }

    //奔走的钟表
    public GameObject OptionDes;
    public GameObject ClockDes;
    /// <summary>
    /// 使用3张觉悟，此后5天，每日获得2张觉悟
    /// </summary>
    public void ClockOne()
    {
        GameManager.instance.cards[(int)Card.Awareness].number -= 3;
        GameManager.instance.doubleAwareness = true;
        GameManager.instance.doubleAwarenessDay = 5;
        ClockDes.SetActive(false);
        OptionDes.SetActive(true);
        Bag.instance.UpdateBag();
        GameManager.instance.SubWorkPoint();
            //todo 场景中钟表跑掉的动画
        
    }
    //空白画布  
    /// <summary>
    /// 消耗一点行动点，获得一份故事
    /// </summary>
    public void Canvas1()
    { 
       GameManager.instance.cards[(int)Card.Story].number += 1;
       GameManager.instance.SubWorkPoint();
    }
    /// <summary>
    /// 消耗一点行动点，使用3张幸运、3张欲望、3张合作绘画，获得一张灵魂，
    /// 此后每日获得一份金钱
    /// </summary>
    public void CanvasOne()
    {
            GameManager.instance.cards[(int)Card.Luck].number -= 3;
            GameManager.instance.cards[(int)Card.Desire].number -= 3;
            GameManager.instance.cards[(int)Card.Cooperation].number -= 3;
            GameManager.instance.cards[(int)Card.Soul].number += 1;
            GameManager.instance.getMoney = true;
        GameManager.instance.SubWorkPoint();

    }

}
