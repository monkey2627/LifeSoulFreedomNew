using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkShop : MonoBehaviour
{

    //԰�ղ�
    /// <summary>
    /// ����һ���ж��㣬ʹ��һ�ž���������ĸ��ÿ�ղ���һ�������һ�Ŵ��죨80%/20%��
    /// </summary>
    public void Shovels1()
    {

            GameManager.instance.cards[(int)Card.Awareness].number -= 1;
            GameManager.instance.creation_creativity = true;
    }
    /// <summary>
    /// ����һ���ж��㣬ʹ��һ�ž�������˻��һ�Ŵ���
    /// </summary>
    public void Shovels2()
    {
            GameManager.instance.cards[(int)Card.Awareness].number -= 1;
            GameManager.instance.cards[(int)Card.Luck].number -= 1;
            GameManager.instance.cards[(int)Card.Creativity].number += 1;
    }
    /// <summary>
    /// ����һ���ж��㣬һ����ʹ��3�ž���󣬻��һ�ź�����
    /// ÿ�ղ���2�������һ�Ŵ��죨50%��50%��������5��
    /// </summary>
    public void Shovels3()
    {
            GameManager.instance.cards[(int)Card.Awareness].number -= 3;
            GameManager.instance.cards[(int)Card.Cooperation].number += 1;
            GameManager.instance.creation2_creativity = 5;
    }
    //��ή��������
    /// <summary>
    /// ����һ���ж��㣬ʹ��һ�ž�����һ����Ϣ/���£�50%/50%��
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
    /// ����һ���ж��㣬ʹ��3�ž���3����֪��3���������������������һ���������˺�ÿ�ջ��һ����Ϣ
    /// </summary>
    public void Tree2()
    {
            GameManager.instance.cards[(int)Card.Awareness].number -= 3;
            GameManager.instance.cards[(int)Card.KnowledgeSeek].number -= 3;
            GameManager.instance.cards[(int)Card.Fight].number -= 3;
            GameManager.instance.cards[(int)Card.Life].number += 1;
            GameManager.instance.getInf = true;
            //todo �����ѵ�������ͼƬ�ı�
    }
}
