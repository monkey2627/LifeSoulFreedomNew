using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPopup :MonoBehaviour
{
    public GameObject[] storys;

    private void OnEnable()
    {
        for(int i = 0; i < storys.Length; i++)
        {
            storys[i].SetActive(false);
        }
        int  j= Random.Range(0, storys.Length);
        storys[j].SetActive(true);
    }
    private void OnDisable()
    {
            GameManager.instance.SubWorkPoint();
    }
}
