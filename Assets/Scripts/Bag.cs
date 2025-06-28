using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����ӱ������϶����ж����߼�
/// </summary>
public class Bag : MonoBehaviour
{
    public static Bag instance;
    private void Start()
    {
        instance = this;
    }
    //�����Ƶ�sprite�����϶�ʱ��ʾ��˳��ͬenum˳��
    public GameObject[] cards;
    //�Ƿ���Ҫ����϶�
    public bool detect = false;

    //������չʾ��sprite��ÿ����Ϊһ��
    public GameObject[] bagCards;

    int dragCardNow = -1;
    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero); // ����һ��ˮƽƽ��

        float distance;
        if (plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance); // �������������ռ��е�λ��
        }

        return Vector3.zero; // ���û�н��㣬����ԭ��
    }
    private void Update()
    {
        //����Ϸ�У���Ҫ����϶�
        if (detect)
        {
            if(dragCardNow != -1)
            {
                cards[dragCardNow].transform.position = GetMouseWorldPosition();
            }
            // ������������
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                // �������ߣ����ǰ������
                if (Physics.Raycast(ray, out hit, 100f)) // 100f �����ߵ���������
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
                    //�����ҵ�����һ������Ŀ���
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
                        //�������У�������
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
                    //�����ж��������ҵ����������active�Ŀ���
                    //�ж�active��ÿһ��ѡ��check
                } 
            }


        }
    }

    /// <summary>
    /// ÿ�ο��Ʒ��������仯ʱ����Ҫ����һ�α�����չʾ
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
