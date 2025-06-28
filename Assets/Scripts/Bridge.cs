using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
   //叹息之雾
   public void Wu()
    {
        if(GameManager.instance.cards[(int)Card.Story].number >= 3)
        {
            GameManager.instance.cards[(int)Card.Story].number -= 3;
            //todo 召唤嬉笑的镜子们
        }
    }
    //召唤嬉笑的镜子们
    public void Mirrors()
    {
        if (GameManager.instance.cards[(int)Card.Cooperation].number >= 3 &&
            GameManager.instance.cards[(int)Card.Trade].number >=3 &&
            GameManager.instance.cards[(int)Card.Fight].number >=3)
        {
            GameManager.instance.cards[(int)Card.Cooperation].number -= 3;
            GameManager.instance.cards[(int)Card.Trade].number -= 3;
            GameManager.instance.cards[(int)Card.Fight].number -= 3;
            GameManager.instance.cards[(int)Card.Freedom].number += 1;
            //todo 召唤门
        }
    }
    //门
    public void Door()
    {
        if (GameManager.instance.cards[(int)Card.Life].number >= 1 &&
            GameManager.instance.cards[(int)Card.Soul].number >= 1 &&
            GameManager.instance.cards[(int)Card.Freedom].number >= 1)
        {
            GameManager.instance.cards[(int)Card.Life].number -= 1;
            GameManager.instance.cards[(int)Card.Soul].number -= 1;
            GameManager.instance.cards[(int)Card.Freedom].number -= 1;
            //todo 进入最终故事
        }
    }
}
