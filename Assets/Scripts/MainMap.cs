using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMap : MonoBehaviour
{
    /// <summary>
    /// ��ʼ��⣬���Ҵ򿪱���
    /// </summary>
    public void OpenScence()
    {
        Bag.instance.detect = true;
        transform.DOMove(new Vector3(12.46f, 0.7f, 0), 2).OnComplete(() => {
            Bag.instance.changes[0].SetActive(true);
            Bag.instance.changes[1].SetActive(true);
            Bag.instance.changes[2].SetActive(true);
        });
        Bag.instance.open = true;
    }
}
