using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public GameObject[] texts;
    public int showNumber = 0;
    public GameObject[] options;
    public int optionsNumber = 0;
    //��Ƶ�̨��
    /// <summary>
    /// ���ѡ����ʾ��һ���ı�
    /// </summary>
    public void Guide()
    {
        texts[showNumber].SetActive(false);
        showNumber++;
        texts[showNumber].SetActive(true);
        StartCoroutine(ShowNext());
    }
    /// <summary>
    /// �ӳ�����������һ��ѡ��
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
        //todo ����ѡ���
        optionsNumber++;
    }

    //���ߵ��ӱ�
    public GameObject OptionDes;
    public GameObject ClockDes;
    /// <summary>
    /// ʹ��3�ž��򣬴˺�5�죬ÿ�ջ��2�ž���
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
            //todo �������ӱ��ܵ��Ķ���
        
    }
    //�հ׻���  
    /// <summary>
    /// ����һ���ж��㣬���һ�ݹ���
    /// </summary>
    public void Canvas1()
    { 
       GameManager.instance.cards[(int)Card.Story].number += 1;
       GameManager.instance.SubWorkPoint();
    }
    /// <summary>
    /// ����һ���ж��㣬ʹ��3�����ˡ�3��������3�ź����滭�����һ����꣬
    /// �˺�ÿ�ջ��һ�ݽ�Ǯ
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
