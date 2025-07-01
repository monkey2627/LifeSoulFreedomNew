using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public GameObject[] things;
    public Option[] options;
    public int ClickTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CloseAll()
    {
        for(int i=0; i < things.Length; i++)
        {
            things[i].SetActive(false);
        }
        //将槽中的卡牌给清空
        for(int i = 0; i < options.Length; i++)
        {
            options[i].ClearAllSlot();
        }
        ClickTime = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
