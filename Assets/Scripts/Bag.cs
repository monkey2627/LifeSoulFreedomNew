using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 处理从背包中拖动，判定等逻辑
/// </summary>
public class Bag : MonoBehaviour
{
    public static Bag instance;
    private void Start()
    {
        instance = this;
    }
    //代表卡牌的sprite，在拖动时显示，顺序同enum顺序
    public GameObject[] cards;
    //是否需要检测拖动
    public bool detect = false;

    //背包中展示的sprite，每三个为一组
    public GameObject[] bagCards;

    int dragCardNow = -1;
    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero); // 创建一个水平平面

        float distance;
        if (plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance); // 返回鼠标在世界空间中的位置
        }

        return Vector3.zero; // 如果没有交点，返回原点
    }
    private void Update()
    {
        //在游戏中，需要检测拖动
        if (detect)
        {
            if(dragCardNow != -1)
            {
                cards[dragCardNow].transform.position = GetMouseWorldPosition();
            }
            // 检测鼠标左键点击
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                // 发射射线，检测前方物体
                if (Physics.Raycast(ray, out hit, 100f)) // 100f 是射线的最大检测距离
                {
                    if (hit.collider.gameObject.tag == "Card")
                    {
                        if (GameManager.instance.cards[int.Parse(hit.collider.gameObject.name)].number > 0)
                        {
                            dragCardNow = int.Parse(hit.collider.gameObject.name);
                            cards[dragCardNow].SetActive(true);
                            cards[dragCardNow].transform.position = GetMouseWorldPosition();
                        }
                    }
                }

            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (dragCardNow != -1) {
                    //首先找到离其一定距离的卡槽
                    CardSlot[] allObjects = GameObject.FindObjectsOfType<CardSlot>();
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
                    //松手判定吸附，找到离其最近且active的卡槽
                    //判定active的每一个选项check
                } 
            }


        }
    }

    /// <summary>
    /// 每次卡牌发生数量变化时，需要更新一次背包的展示
    /// </summary>
    public void UpdateBag()
    {
       for(int i = 0; i < 19; i++)
       {
             if (GameManager.instance.cards[i].number == 1 || GameManager.instance.cards[i].number == 0)
            {
                bagCards[i * 2].SetActive(false);  
                bagCards[i * 2+1].SetActive(false);    
            }else if (GameManager.instance.cards[i].number == 2)
            {
                bagCards[i * 2].SetActive(true);
                bagCards[i * 2 + 1].SetActive(false);
            }
            else if(GameManager.instance.cards[i].number >=3)
            {
                bagCards[i * 2].SetActive(true);
                bagCards[i * 2 + 1].SetActive(true);
            }
        }
    }
    public bool open = false;
    public bool isMove = false;
    public GameObject[] changes;
    public void OpenBag()
    {
        UpdateBag();
        if (open == false && !isMove)
        {
            isMove = true;
            transform.DOMove(new Vector3(12.46f, 0.7f, 0), 2).OnComplete(()=> { isMove = false;
                changes[0].SetActive(true);
                changes[1].SetActive(true);
                changes[2].SetActive(true);
            });
            open = true;
        }
        else if(!isMove)
        {
            isMove = true;  
            changes[0].SetActive(false);
            changes[1].SetActive(false);
            changes[2].SetActive(false);
            transform.DOMove(new Vector3(16.24f, 0.7f, 0), 2).OnComplete(() => { isMove = false;  
            }); ;
            open = false;
        }
    }
}
