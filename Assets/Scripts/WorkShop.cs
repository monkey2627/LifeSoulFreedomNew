using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkShop : MonoBehaviour
{

    //园艺铲
    /// <summary>
    /// 消耗一点行动点，使用一张觉悟种下螺母，每日产出一张造物或一张创造（80%/20%）
    /// </summary>
    public void Shovels1()
    {

            GameManager.instance.cards[(int)Card.Awareness].number -= 1;
            GameManager.instance.creation_creativity = true;
    }
    /// <summary>
    /// 消耗一点行动点，使用一张觉悟和幸运获得一张创造
    /// </summary>
    public void Shovels2()
    {
            GameManager.instance.cards[(int)Card.Awareness].number -= 1;
            GameManager.instance.cards[(int)Card.Luck].number -= 1;
            GameManager.instance.cards[(int)Card.Creativity].number += 1;
    }
    /// <summary>
    /// 消耗一点行动点，一次性使用3张觉悟后，获得一张合作，
    /// 每日产出2张造物或一张创造（50%，50%），持续5天
    /// </summary>
    public void Shovels3()
    {
            GameManager.instance.cards[(int)Card.Awareness].number -= 3;
            GameManager.instance.cards[(int)Card.Cooperation].number += 1;
            GameManager.instance.creation2_creativity = 5;
    }
    //枯萎的世界树
    /// <summary>
    /// 消耗一点行动点，使用一张觉悟获得一份信息/故事（50%/50%）
    /// </summary>
    public void Tree1()
    {
            GameManager.instance.cards[(int)Card.Awareness].number -= 1;
            int t = Random.Range(1, 3);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Story].number += 1;
        }
        else
        {
            GameManager.instance.cards[(int)Card.Information].number += 1;
        }
    }
    /// <summary>
    /// 消耗一点行动点，使用3张觉悟、3张求知、3张争斗唤醒世界树，获得一张生命，此后每日获得一份信息
    /// </summary>
    public void Tree2()
    {
            GameManager.instance.cards[(int)Card.Awareness].number -= 3;
            GameManager.instance.cards[(int)Card.KnowledgeSeek].number -= 3;
            GameManager.instance.cards[(int)Card.Fight].number -= 3;
            GameManager.instance.cards[(int)Card.Life].number += 1;
            GameManager.instance.getInf = true;
            //todo 被唤醒的世界树图片改变
    }
}
