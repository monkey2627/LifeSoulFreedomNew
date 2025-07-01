using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sholve : MonoBehaviour
{
    public int type;
    public GameObject Getcreation;
    public GameObject Getcreativity;
    public GameObject Get2creation;
    /// <summary>
    /// 每次出现调用
    /// </summary>
    private void OnEnable()
    {
        if (type == 0)
        {
            int t = Random.Range(0, 5);
            if (t == 0)
            {
               Getcreativity.SetActive(true);
                GameManager.instance.cards[(int)Card.Creativity].number += 1;
            }
            else
            {
                Getcreation.SetActive(true);
                GameManager.instance.cards[(int)Card.Creation].number += 1;
            }
        }
        if (type == 1)
        {
            int t = Random.Range(0, 2);
            if (t == 0)
            {
                Getcreativity.SetActive(true);
                GameManager.instance.cards[(int)Card.Creativity].number += 1;
            }
            else
            {
               Get2creation.SetActive(true);
               GameManager.instance.cards[(int)Card.Creation].number += 2;
            }
        }
        Bag.instance.UpdateBag();
    }
    private void OnDisable()
    {
        Get2creation.SetActive(false);  
        Getcreation.SetActive(false);
        Getcreativity.SetActive(false);
    }
}
