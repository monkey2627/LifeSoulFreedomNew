using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 处理从背包中拖动，判定等逻辑
/// </summary>
public class Bag : MonoBehaviour
{


    public void BeginDetect()
    {
        detect = true;
    }
    public static Bag instance;
    private void Start()
    {
        instance = this;
        gameObject.SetActive(false);
        GameManager.instance.cards[(int)Card.Money].number = 2;
        GameManager.instance.cards[(int)Card.Awareness].number = 2;
    }
    //代表卡牌的sprite，在拖动时显示，顺序同enum顺序
    public GameObject[] cards;
    //是否需要检测拖动
    public bool detect = false;

    //背包中展示的sprite，每三个为一组
    public GameObject[] bagCards;

    public int dragCardNow = -1;
    public GameObject plane;
    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // 发射射线，检测前方物体
        if (Physics.Raycast(ray, out hit, 100f)) // 100f 是射线的最大检测距离
        { 
            if(hit.collider.gameObject.tag == "Plane" || hit.collider.gameObject.tag == "Card")
            {
                return hit.point;
            }
        
        }

        return cards[dragCardNow].transform.position; // 如果没有交点，返回原点
    }
    public bool MoveOut = false;
    public CardSlot outSlot = null;
    private void Update()
    {
        if (GameManager.instance.TanChuangZhuangTai)
        {
            if (dragCardNow != -1)
            {
                cards[dragCardNow].SetActive(false);
                dragCardNow = -1;
            }
            return;
        }
          
        //在游戏中，需要检测拖动
        if (detect)
        {
            if(dragCardNow != -1)
            {
                if (Input.GetMouseButton(0))
                { 
                    cards[dragCardNow].transform.position = GetMouseWorldPosition();
                    //所有的卡槽显示的卡位置改变
                    CardSlot[] allObjects = GameObject.FindObjectsOfType<CardSlot>();
                    foreach (var item in allObjects)
                    {
                        item.MoveCardBack();
                    }
                }
                
            }
            // 检测鼠标左键点击
            if (Input.GetMouseButtonDown(0))
            {

                CardSlot[] allObjects = GameObject.FindObjectsOfType<CardSlot>();
                foreach (var item in allObjects)
                {
                    item.MoveCardUp();
                }
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                // 发射射线，检测前方物体
                if (Physics.Raycast(ray, out hit, 100f)) // 100f 是射线的最大检测距离
                {
      
                   // Debug.Log(hit.collider.name);
                    if (hit.collider.gameObject.tag == "Card")
                    {
                        Debug.Log("haha");
                        if (GameManager.instance.cards[int.Parse(hit.collider.gameObject.name)].number > 0)
                        {
                            Debug.Log(int.Parse(hit.collider.gameObject.name));
                            Debug.Log(GameManager.instance.cards[int.Parse(hit.collider.gameObject.name)].number);
                            dragCardNow = int.Parse(hit.collider.gameObject.name);
                            cards[dragCardNow].SetActive(true);

                            cards[dragCardNow].transform.position = GetMouseWorldPosition();
                        }
                    }
                    else if(hit.collider.gameObject.tag == "CardIn")
                        //是把牌从里面拖出来
                    {
                        dragCardNow = int.Parse(hit.collider.gameObject.name);
                        cards[dragCardNow].SetActive(true);
                        cards[dragCardNow].transform.position = GetMouseWorldPosition();
                        outSlot = hit.collider.transform.parent.GetComponent<CardSlot>();
                        outSlot.RemoveCard();
                        MoveOut = true;
                    }
                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                CardSlot[] allObjects = GameObject.FindObjectsOfType<CardSlot>();
                foreach (var item in allObjects)
                {
                    item.MoveCardUp();
                }
                if (dragCardNow != -1) {

                    if (MoveOut)
                    {
                        if ((outSlot.transform.position - cards[dragCardNow].transform.position).magnitude < 0.5f)
                        {

                            MoveOut = false;
                            outSlot.PushCard((Card)dragCardNow);
                            outSlot = null;
                        }
                        else
                        {
                            MoveOut = false;
                            outSlot = null;
                        }
                        cards[dragCardNow].SetActive(false);
                        dragCardNow = -1;
                        return;
                    }
                    //首先找到离其一定距离的卡槽
                    allObjects = GameObject.FindObjectsOfType<CardSlot>();
                    int t = 0;
                    float s = 10000;
                    for (int i = 0; i < allObjects.Length; i++)
                    {
                        if ((allObjects[i].transform.position - cards[dragCardNow].transform.position).magnitude < s)
                        {
                            t = i;
                            s = (allObjects[i].transform.position - cards[dragCardNow].transform.position).magnitude;
                        }
                    }
                    if(s < 0.5)
                    {
                        //本来就有，不管了
                        if (allObjects[t].option.CheckIfHas(dragCardNow))
                        {
                            cards[dragCardNow].SetActive(false);
                            dragCardNow = -1;
                        }
                        else
                        {
                            allObjects[t].PushCard((Card)dragCardNow);
                        }
                    }
                    else
                    {
                        cards[dragCardNow].SetActive(false);
                        dragCardNow = -1;
                    }
                    //松手判定吸附，找到离其最近且active的卡槽
                    //判定active的每一个选项check
                    if (dragCardNow != -1)
                    {
                        cards[dragCardNow].SetActive(false);
                        dragCardNow = -1;
                    }
                } 


            }


        }
    }

    public GameObject[] cs;
    public TMPro.TMP_Text[] texts;
    /// <summary>
    /// 每次卡牌发生数量变化时，需要更新一次背包的展示
    /// </summary>
    public void UpdateBag()
    {
       for(int i = 0; i < 19; i++)
       {
            texts[i].text = GameManager.instance.cards[i].number.ToString();
             if (GameManager.instance.cards[i].number == 1)
            {
                cs[i].SetActive(true);
                bagCards[i * 2].SetActive(false);  
                bagCards[i * 2+1].SetActive(false);    
            }else if (GameManager.instance.cards[i].number == 2)
            {
                cs[i].SetActive(true);
                bagCards[i * 2].SetActive(true);
                bagCards[i * 2 + 1].SetActive(false);
            }
            else if(GameManager.instance.cards[i].number >=3)
            {
                cs[i].SetActive(true);
                bagCards[i * 2].SetActive(true);
                bagCards[i * 2 + 1].SetActive(true);
            }else if ( GameManager.instance.cards[i].number == 0)
            {
                cs[i].SetActive(false);
            }
        }
    }
    public bool open = false;
    public bool isMove = false;
    public GameObject[] changes;
    public void OpenBag()
    {
        Debug.Log("move");
        if (detect) return;

        UpdateBag();
        if (open == false && !isMove)
        {
            isMove = true;
            transform.DOMove(new Vector3(5.49f, -0.3f, -1.6f), 2).OnComplete(()=> { isMove = false;
                changes[0].SetActive(true);
                changes[1].SetActive(true);
                changes[2].SetActive(true);
            });
            open = true;
            VoiceManager.instance.OpenBag();
        }
        else if(!isMove)
        {
            isMove = true;  
            changes[0].SetActive(false);
            changes[1].SetActive(false);
            changes[2].SetActive(false);
            transform.DOMove(new Vector3(9.05f, -0.3f, -1.6f), 2).OnComplete(() => { isMove = false;  
            }); ;
            open = false;
            VoiceManager.instance.CloseBag();
        }
    }
}
