using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
   //̾Ϣ֮��
   public void Wu()
    {
        if(GameManager.instance.cards[(int)Card.Story].number >= 3)
        {
            GameManager.instance.cards[(int)Card.Story].number -= 3;
            //todo �ٻ���Ц�ľ�����
        }
    }
    //�ٻ���Ц�ľ�����
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
            //todo �ٻ���
        }
    }
    //��
    public void Door()
    {
        if (GameManager.instance.cards[(int)Card.Life].number >= 1 &&
            GameManager.instance.cards[(int)Card.Soul].number >= 1 &&
            GameManager.instance.cards[(int)Card.Freedom].number >= 1)
        {
            GameManager.instance.cards[(int)Card.Life].number -= 1;
            GameManager.instance.cards[(int)Card.Soul].number -= 1;
            GameManager.instance.cards[(int)Card.Freedom].number -= 1;
            //todo �������չ���
        }
    }
}
