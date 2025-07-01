using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkShop : MonoBehaviour
{
    public GameObject shovle;
    public GameObject treeDie;
    public GameObject tree;

    //԰�ղ�
    /// <summary>
    /// ����һ���ж��㣬ʹ��һ�ž���������ĸ��ÿ�ղ���һ�������һ�Ŵ��죨80%/20%��
    /// </summary>
    public GameObject sOption;
    public GameObject sDes;
    public GameObject sOptDes1;
    public GameObject sOptDes2;
    public GameObject sOptDes3;
    public void ClickS()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        treeDie.GetComponent<Npc>().CloseAll();
        if (shovle.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        shovle.GetComponent<Npc>().ClickTime += 1;
        tree.GetComponent<Npc>().CloseAll();
        shovle.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            shovle.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                shovle.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    shovle.transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                });
            });

        });
        sOptDes1.SetActive(false);
        sOptDes2.SetActive(false);
        sOptDes3.SetActive(false);
        if (GameManager.instance.creation2_creativity > 0)
        {
            sOptDes4.SetActive(true);
            sOption2.SetActive(true);
        }else if(GameManager.instance.creation_creativity)
        {
            sOption3.SetActive(true);
            sOptDes4.SetActive(true);
        }
        else
        {
            sOption.SetActive(true);
            sDes.SetActive(true);
        }
    }
    public GameObject sOptDes4;
    public GameObject sOption2;
    public GameObject sOption3;
    public void Shovels1()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        sDes.SetActive(false);
        sOptDes1.SetActive(true);
        sOption2.SetActive(false);
        sOption.SetActive(false);
        sOption3.SetActive(true);
        GameManager.instance.creation_creativity = true;
        GameManager.instance.SubWorkPoint();
        Bag.instance.UpdateBag();
    }
    /// <summary>
    /// ����һ���ж��㣬ʹ��һ�ž�������˻��һ�Ŵ���
    /// </summary>
    public void Shovels2()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        sDes.SetActive(false);
        sOptDes4.SetActive(false);
        sOptDes2.SetActive(true);
        GameManager.instance.cards[(int)Card.Creativity].number += 1;
        GetPopup.instance.ShowGets(9);
        GetPopup.instance.gameObject.SetActive(true);
        GetPopup.instance.work = true;
        Bag.instance.UpdateBag();
    }
    /// <summary>
    /// ����һ���ж��㣬һ����ʹ��3�ž���󣬻��һ�ź�����
    /// ÿ�ղ���2�������һ�Ŵ��죨50%��50%��������5��
    /// </summary>
    public void Shovels3()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        sDes.SetActive(false);
        sOptDes3.SetActive(true);
        sOption.SetActive(false);
        sOption3.SetActive(false);
        sOption2.SetActive(true);
        GameManager.instance.cards[(int)Card.Cooperation].number += 1;
        GetPopup.instance.ShowGets(10);
        GetPopup.instance.gameObject.SetActive(true);
        GetPopup.instance.work = true;
        Bag.instance.UpdateBag();
        GameManager.instance.creation2_creativity = 5;
    }
    //��ή��������
    public GameObject treeDes;
    public GameObject inf;
    public GameObject treeOpt1;
    public GameObject treeOptDes1;

    public void ClickT()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (treeDie.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        treeDie.GetComponent<Npc>().ClickTime += 1;
        shovle.GetComponent<Npc>().CloseAll();
        treeDie.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            treeDie.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                treeDie.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    treeDie.transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                });
            });

        });
        treeOptDes1.SetActive(false);
        inf.SetActive(false);
        if(treeDes)
            treeDes.SetActive(true);
        treeOpt1.SetActive(true);
    }
    //���յ���
    public GameObject treeAwakeDes;
    public void ClickTreeAwake()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (tree.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        tree.GetComponent<Npc>().ClickTime += 1;
        shovle.GetComponent<Npc>().CloseAll();
        treeDie.GetComponent<Npc>().CloseAll();
        tree.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            tree.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                tree.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    tree.transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                });
            });

        });
        treeAwakeDes.SetActive(true);
    }
    /// <summary>
    /// ����һ���ж��㣬ʹ��һ�ž�����һ����Ϣ/���£�50%/50%��
    /// </summary>
    public void Tree1()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        int t = Random.Range(1, 3);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Story].number += 1;
            GetPopup.instance.ShowGets(0);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        else
        {
            GameManager.instance.cards[(int)Card.Information].number += 1;
            treeDes.SetActive(false);
            inf.SetActive(true);
            GetPopup.instance.ShowGets(8);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
      
        Bag.instance.UpdateBag();  
    
    }
    /// <summary>
    /// ����һ���ж��㣬ʹ��3�ž���3����֪��3���������������������һ���������˺�ÿ�ջ��һ����Ϣ
    /// </summary>
    public void Tree2()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        GameManager.instance.cards[(int)Card.Life].number += 1;
        GameManager.instance.getInf = true;
        treeDes.SetActive(false);
        treeOptDes1.SetActive(true);
        tree.SetActive(true);
        treeDie.SetActive(false);
        Bag.instance.UpdateBag();
        GetPopup.instance.ShowGets(18);
        GetPopup.instance.gameObject.SetActive(true);
        GetPopup.instance.work = true;
    }

    public void Back()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.CloseScence();
        gameObject.SetActive(false);
        VoiceManager.instance.CloseScence();
        Bag.instance.detect = false;
        treeDie.GetComponent<Npc>().CloseAll();
        shovle.GetComponent<Npc>().CloseAll();
    }
    private void OnDisable()
    {
        VoiceManager.instance.CloseScence();
        gameObject.SetActive(false);
        VoiceManager.instance.CloseScence();
        Bag.instance.detect = false;
        treeDie.GetComponent<Npc>().CloseAll();
        shovle.GetComponent<Npc>().CloseAll();
    }
}
