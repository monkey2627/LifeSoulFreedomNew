using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theater : MonoBehaviour
{
    public static Theater instance;
    public GameObject pen;
    public GameObject mask;
    public GameObject drum;
    public GameObject flower;
    public GameObject badWords;
    public GameObject lunPan;
    public GameObject tanxi;
    private void Awake()
    {
        instance = this;
    }
   public int find()
    {
        while (true)
        {
            int t = Random.Range(0, 8);
            if(GameManager.instance.cards[t].number > 0)
            {
                return t;
            }
        }
    }
    //妒火的面具
    public GameObject maskDes;
    public GameObject maskOptionA;
    public GameObject maskOptionB;
    public GameObject maskOptionDes1;
    public GameObject maskOptionDes2;
    public TMPro.TMP_Text maskText;
    public GameObject maskTextp;
    public void ClickMask()
    {

        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        mask.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            mask.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {
                mask.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    mask.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        maskOptionDes1.SetActive(false);
        maskOptionDes2.SetActive(false);
        if(GameManager.instance.CrazyFree > 0)
        {
            maskOptionB.SetActive(true);
            maskOptionA.SetActive(false);
        }
        else
        {
            maskOptionA.SetActive(true);
            maskOptionB.SetActive(false);
        }
        
        maskDes.SetActive(true);
        pen.GetComponent<Npc>().CloseAll();
        drum.GetComponent<Npc>().CloseAll();
        flower.GetComponent<Npc>().CloseAll();
        badWords.GetComponent<Npc>().CloseAll();
        lunPan.GetComponent<Npc>().CloseAll();
        tanxi.GetComponent<Npc>().CloseAll();
    }
    /// <summary>
    /// 消耗一点行动点，获得一份疯狂，积攒3份疯狂会撕毁一张随机普通牌
    /// </summary>
    public void Mask1()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        GameManager.instance.chooseMask = true;
        GameManager.instance.cards[(int)Card.Crazy].number += 1;
        Bag.instance.UpdateBag();
        maskDes.SetActive(false);
        maskOptionDes2.SetActive(false);
        maskOptionDes1.SetActive(true);
        GetPopup.instance.ShowGets(3);
        GetPopup.instance.gameObject.SetActive(true);
        GetPopup.instance.work = true;
    }
    public string[] deses;
    /// <summary>
    /// Special（无法疯狂）,消耗一点行动点
    /// </summary>
    public void Mask2()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        maskDes.SetActive(false);
        maskOptionDes1.SetActive(false);
        maskOptionDes2.SetActive(true);
        GameManager.instance.SubWorkPoint();
    }
    //叹息之幕（常驻)
    public GameObject tOption;
    public GameObject tDes;
    public GameObject tDes1;
    public GameObject tDes2;
    public void ClickT()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        tanxi.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            tanxi.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                tanxi.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    tanxi.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        tDes1.SetActive(false);
        tDes2.SetActive(false);
        tOption.SetActive(true);
        tDes.SetActive(true);
        pen.GetComponent<Npc>().CloseAll();
        mask.GetComponent<Npc>().CloseAll();
        drum.GetComponent<Npc>().CloseAll();
        flower.GetComponent<Npc>().CloseAll();
        badWords.GetComponent<Npc>().CloseAll();
        lunPan.GetComponent<Npc>().CloseAll();
    }
    public GameObject WufaFengkuang;
    public void Tanxi1()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        tDes.SetActive(false);
        tDes1.SetActive(true);
        tDes2.SetActive(false);
        GameManager.instance.cards[(int)Card.Awakeness].number += 1;
        GameManager.instance.awakeNumber++;
        GetPopup.instance.ShowGets(15);
        GetPopup.instance.gameObject.SetActive(true);
        GetPopup.instance.work = true;
        Bag.instance.UpdateBag();
    }
    /// <summary>
    /// 用6份疯狂换取一张欲望/幸运（70%，30%）
    /// </summary>
    public void Tanxi2()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        tDes.SetActive(false);
        tDes1.SetActive(false);
        tDes2.SetActive(true);
        int t = Random.Range(1, 11);
            if (t <=7)
            {
                GameManager.instance.cards[(int)Card.Desire].number += 1;
            GetPopup.instance.ShowGets(14);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
            else
            {
                GameManager.instance.cards[(int)Card.Luck].number += 1;
            GetPopup.instance.ShowGets(13);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }

        Bag.instance.UpdateBag();
    }
    //挑衅的鼓
    public GameObject guOption;
    public GameObject guDes;
    public GameObject guOptDes1;
    public GameObject guOptDes2;
    public bool isLunpan = false;
    public void ClickGu()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (isLunpan) return;
        drum.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            drum.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                drum.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    drum.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        guOptDes1.SetActive(false);
        guOptDes2.SetActive(false);
;        guOption.SetActive(true);
        guDes.SetActive(true);
        pen.GetComponent<Npc>().CloseAll();
        mask.GetComponent<Npc>().CloseAll();
        flower.GetComponent<Npc>().CloseAll();
        badWords.GetComponent<Npc>().CloseAll();
        lunPan.GetComponent<Npc>().CloseAll();
        tanxi.GetComponent<Npc>().CloseAll();
    }
    /// <summary>
    /// 消耗一点行动点，用1份疯狂和1份觉悟召唤一次激情的轮盘
    /// </summary>
    public void Gu1()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        if (isLunpan)
            return;
        isLunpan = true;
        Bag.instance.UpdateBag();
        guDes.SetActive(false);
        guOptDes1.SetActive(true);
        guOption.SetActive(false);
        lunPan.GetComponent<SpriteRenderer>().DOFade(1, 1);
        lunPan.transform.DOScale(new Vector3(0.41f, 0.41f, 0.41f), 1);
        lunPan.transform.DORotate(new Vector3(0, 0, 360), 1).OnComplete(()=> {
            GameManager.instance.SubWorkPoint();
            win = 0;

        });
    }
    public void Gu2()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        guDes.SetActive(false);
        guOptDes2.SetActive(true);
    }
    //激情的轮盘
    public int win = 0;

    public GameObject GameView;
    public GameObject lunpanOption;
    public GameObject lunpanDes;
    public void ClickLunpan()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        lunPan.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            lunPan.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                lunPan.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    lunPan.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        pen.GetComponent<Npc>().CloseAll();
        mask.GetComponent<Npc>().CloseAll();
        drum.GetComponent<Npc>().CloseAll();
        flower.GetComponent<Npc>().CloseAll();
        badWords.GetComponent<Npc>().CloseAll();
        tanxi.GetComponent<Npc>().CloseAll();
        lunpanOption.SetActive(true);
        lunpanDes.SetActive(true);
    }
    /// <summary>
    /// 消耗行动点1，结算后才消耗 
    /// 与挑衅的鼓进行轮盘内的石头剪刀布（轮盘的数字换成石头剪刀布），
    /// 胜利后获得3金钱，失败则获得1疯狂。连续胜利2次后获得一张争斗
    /// </summary>
    public void Roulette()
    {
        startGame = true;
        GameView.SetActive(true);
    }
    bool getShitou = false;
    bool getJiandap= false;
    bool getBu = false;
    public void RouletteGetShiTou()
    {
        if (getShitou) return;
        getShitou = true;
        sjb[4].SetActive(false);
        sjb[5].SetActive(false);
        lunpanGame.transform.DOShakeScale(1);
        lunpanGame.transform.DORotate(new Vector3(0, 0, 1872), 3).OnComplete(() => {
            int t = Random.Range(0, 3);
        sjb[0].SetActive(false);
        sjb[1].SetActive(false);
        sjb[2].SetActive(false);
        sjb[t].SetActive(true);
        sjb[t].transform.localScale = new Vector3(1, 1, 1);
        sjb[t].GetComponent<SpriteRenderer>().DOFade(0, 0.01f);
        sjb[t].GetComponent<SpriteRenderer>().DOFade(1, 1f);           
        sjb[t].transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1).OnComplete(()=> {
        if (t == 1)
        {
                win++;
                if (win == 2)
                {
                    GameManager.instance.cards[(int)Card.Fight].number += 1;
                    GameManager.instance.cards[(int)Card.Money].number += 3;
                    Bag.instance.UpdateBag();
                    delay.transform.DOMove(new Vector3(-1, -1, -1), 1.5f).OnComplete(() =>
                    {
                        doublePanel.SetActive(true);
                    });
                }
                else
                {
                    GameManager.instance.cards[(int)Card.Money].number += 3;
                    Bag.instance.UpdateBag();
                    delay.transform.DOMove(new Vector3(-1, -1, -1), 1.5f).OnComplete(() =>
                    {
                        winPanel.SetActive(true);
                    });
                }
        }else if (t == 2)
        {
                delay.transform.DOMove(new Vector3(-1, -1, -1), 1.5f).OnComplete(() =>
                {
                    losePanel.SetActive(true);
                });
                GameManager.instance.cards[(int)Card.Crazy].number += 3;
                Bag.instance.UpdateBag();
            }
            else
            {
                delay.transform.DOMove(new Vector3(-1, -1, -1), 1.5f).OnComplete(() =>
                {
                    samePanel.SetActive(true);
                });
                Bag.instance.UpdateBag();
            }
        
         });
        });
        
    }
    public GameObject delay;
    public GameObject lunpanGame;
    public void RouletteGetjiandao()
    {
        if (getJiandap) return;
        getJiandap = true;
        sjb[3].SetActive(false);
        sjb[5].SetActive(false);
        lunpanGame.transform.DOShakeScale(1);
        lunpanGame.transform.DORotate(new Vector3(0, 0, 1872), 3).OnComplete(() => {
            int t = Random.Range(0, 3);
            sjb[0].SetActive(false);
            sjb[1].SetActive(false);
            sjb[2].SetActive(false);
            sjb[t].SetActive(true);
            sjb[t].transform.localScale = new Vector3(1, 1, 1);
            sjb[t].GetComponent<SpriteRenderer>().DOFade(0, 0.01f);
            sjb[t].GetComponent<SpriteRenderer>().DOFade(1, 1f);
            sjb[t].transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1).OnComplete(()=> { 
            
                if (t == 2)
                {
                    win++;
                    if (win == 2)
                    {
                        GameManager.instance.cards[(int)Card.Fight].number += 1;
                        GameManager.instance.cards[(int)Card.Money].number += 3;
                        Bag.instance.UpdateBag();
                        delay.transform.DOMove(new Vector3(-1, -1, -1), 1.5f).OnComplete(() =>
                        {
                            doublePanel.SetActive(true);

                        });
                        
                    }
                    else
                    {
                        GameManager.instance.cards[(int)Card.Money].number += 3;
                        Bag.instance.UpdateBag();
                        delay.transform.DOMove(new Vector3(-1, -1, -1), 1.5f).OnComplete(() =>
                        {
                            winPanel.SetActive(true);
                        });
                    }
                }
                else if (t == 0)
                {
                    delay.transform.DOMove(new Vector3(-1, -1, -1), 1.5f).OnComplete(() =>
                    {
                        losePanel.SetActive(true);
                    });
                    GameManager.instance.cards[(int)Card.Crazy].number += 3;
                    Bag.instance.UpdateBag();
                }
                else
                {
                    delay.transform.DOMove(new Vector3(-1, -1, -1), 1.5f).OnComplete(() =>
                    {
                        samePanel.SetActive(true);
                    });
                    Bag.instance.UpdateBag();
                }
            
            
            });
          
        });

    }
    public void RouletteGetBu()
    {
        if (getBu) return;
        getBu = true;
        sjb[3].SetActive(false);
        sjb[4].SetActive(false);
        lunpanGame.transform.DOShakeScale(1);
        lunpanGame.transform.DORotate(new Vector3(0, 0, 1872), 3).OnComplete(() => {
            int t = Random.Range(0, 3);
            sjb[0].SetActive(false);
            sjb[1].SetActive(false);
            sjb[2].SetActive(false);
            sjb[t].SetActive(true);
            sjb[t].transform.localScale = new Vector3(1, 1, 1);
            sjb[t].GetComponent<SpriteRenderer>().DOFade(0, 0.01f);
            sjb[t].GetComponent<SpriteRenderer>().DOFade(1, 1f);
            sjb[t].transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1).OnComplete(()=> { 
            if (t == 0)
            {
                win++;
                if (win == 2)
                {
                    GameManager.instance.cards[(int)Card.Fight].number += 1;
                    GameManager.instance.cards[(int)Card.Money].number += 3;
                    Bag.instance.UpdateBag();
                        delay.transform.DOMove(new Vector3(-1, -1, -1), 1.5f).OnComplete(() =>
                        {
                            doublePanel.SetActive(true);
                        });
                }
                else
                {
                    GameManager.instance.cards[(int)Card.Money].number += 3;
                    Bag.instance.UpdateBag();
                        delay.transform.DOMove(new Vector3(-1, -1, -1), 1.5f).OnComplete(() =>
                        {
                            winPanel.SetActive(true);
                        });
                }
            }
            else if (t == 1)
            {
                    delay.transform.DOMove(new Vector3(-1, -1, -1), 1.5f).OnComplete(() =>
                    {
                        losePanel.SetActive(true);
                    });
                GameManager.instance.cards[(int)Card.Crazy].number += 3;
                Bag.instance.UpdateBag();
            }
            else
            {
                    delay.transform.DOMove(new Vector3(-1, -1, -1), 1.5f).OnComplete(() =>
                    {
                        samePanel.SetActive(true);
                    });
                    Bag.instance.UpdateBag();
            }});
        });

    }
    /// <summary>
    /// 此处处理行动点之类的问题
    /// </summary>
    public void LunpanJiesuan()
    {
        GameView.SetActive(false);
        sjb[0].SetActive(false);
        sjb[1].SetActive(false);
        sjb[2].SetActive(false);
        getShitou = false;
        getJiandap = false;
        getBu = false;
        sjb[3].SetActive(true);
        sjb[4].SetActive(true);
        sjb[5].SetActive(true);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        samePanel.SetActive(false);
        doublePanel.SetActive(false);
        GameManager.instance.SubWorkPoint();
    }
    public GameObject winPanel;
    public GameObject doublePanel;
    public GameObject samePanel;
    public GameObject losePanel;
    bool startGame = false;
    public GameObject[] sjb;
    //充满决心的圆珠笔（常驻)
    public GameObject penOption;
    public GameObject penDes;
    public GameObject penDesOpt1;
    public GameObject penDesOpt2;
    public void ClickPen()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        pen.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            pen.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                pen.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    pen.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        penDesOpt1.SetActive(false);
        penDesOpt2.SetActive(false);
        mask.GetComponent<Npc>().CloseAll();
        drum.GetComponent<Npc>().CloseAll();
        flower.GetComponent<Npc>().CloseAll();
        badWords.GetComponent<Npc>().CloseAll();
        lunPan.GetComponent<Npc>().CloseAll();
        tanxi.GetComponent<Npc>().CloseAll();
        penOption.SetActive(true);
        penDes.SetActive(true);
    }
    /// <summary>
    /// 消耗一点行动点，使用一张觉悟获得信息和1金钱，可能（25%）获得争斗
    /// </summary>
    public void Pen1()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        Debug.Log(GameManager.instance.cards[(int)Card.Money].number);
        GameManager.instance.cards[(int)Card.Information].number += 1;
        GameManager.instance.cards[(int)Card.Money].number += 1;
        penDes.SetActive(false);
        penDesOpt2.SetActive(false);
        penDesOpt1.SetActive(true);
        int t = Random.Range(1, 5);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Fight].number += 1;
            GetPopup.instance.ShowGets(35);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        else
        {
            GetPopup.instance.ShowGets(19);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;

        }
        
        Bag.instance.UpdateBag();
    }
    /// <summary>
    /// 消耗一点行动点，使用2张任意普通牌获得一张争斗或一张欲望
    /// </summary>
    public void Pen2()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        penDes.SetActive(false);
        penDesOpt1.SetActive(false);
        penDesOpt2.SetActive(true);
        int t = Random.Range(1, 3);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Fight].number += 1;
            GetPopup.instance.ShowGets(6);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        else
        {
            GameManager.instance.cards[(int)Card.Desire].number += 1;
            GetPopup.instance.ShowGets(14);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        Bag.instance.UpdateBag();
    }
    //荒芜花束
    /// <summary>
    /// 不消耗行动点，获得一张幸运/希望（接下来3天收益+1）（80%/20%）
    /// </summary>
    /// 
    public GameObject fDes;
    public bool flowerFirstClick = true;
    public void Flower()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (!flowerFirstClick) return;
        flowerFirstClick = false;
        pen.GetComponent<Npc>().CloseAll();
        mask.GetComponent<Npc>().CloseAll();
        drum.GetComponent<Npc>().CloseAll();
        badWords.GetComponent<Npc>().CloseAll();
        lunPan.GetComponent<Npc>().CloseAll();
        tanxi.GetComponent<Npc>().CloseAll();
        flower.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            flower.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                flower.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    flower.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        fDes.SetActive(true);
        int t = Random.Range(1, 6);
        if (t == 2)
        {
            GameManager.instance.cards[(int)Card.Hope].number = 3;
            GetPopup.instance.ShowGets(12);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        else
        {
            GameManager.instance.cards[(int)Card.Luck].number += 1;
            GetPopup.instance.ShowGets(13);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
        }
        Bag.instance.UpdateBag();
    }
    /// <summary>
    /// 游荡恶语（撕毁2张随机普通牌后出现，每次出现一天）：
    /// 不消耗行动点，获得一张争斗/绝望（接下来3天收益-1）（50%/50%）
    /// </summary>
    public GameObject bwDes;
    public bool badWordFirstClick = true;
    public void BadWord()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (!badWordFirstClick) return;
        badWordFirstClick = false;
        pen.GetComponent<Npc>().CloseAll();
        mask.GetComponent<Npc>().CloseAll();
        drum.GetComponent<Npc>().CloseAll();
        flower.GetComponent<Npc>().CloseAll();
        lunPan.GetComponent<Npc>().CloseAll();
        tanxi.GetComponent<Npc>().CloseAll();
        badWords.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            badWords.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                badWords.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    badWords.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        bwDes.SetActive(true);
        int t = Random.Range(1, 3);
        if (t == 2)
        { 
            GetPopup.instance.ShowGets(17);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
            GameManager.instance.cards[(int)Card.Desperate].number = 3;
        }
        else
        {
            GetPopup.instance.ShowGets(6);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
            GameManager.instance.cards[(int)Card.Fight].number += 1;
        }
       
        Bag.instance.UpdateBag();
    }
    public GameObject mainMap;
    public void Back()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        gameObject.SetActive(false);
        mainMap.SetActive(true);
        VoiceManager.instance.CloseScence();
        pen.GetComponent<Npc>().CloseAll();
        mask.GetComponent<Npc>().CloseAll();
        drum.GetComponent<Npc>().CloseAll();
        flower.GetComponent<Npc>().CloseAll();
        badWords.GetComponent<Npc>().CloseAll();
        lunPan.GetComponent<Npc>().CloseAll();
        tanxi.GetComponent<Npc>().CloseAll();
        Bag.instance.detect = false;
    }
    private void OnDisable()
    {
        gameObject.SetActive(false);
        mainMap.SetActive(true);
        pen.GetComponent<Npc>().CloseAll();
        mask.GetComponent<Npc>().CloseAll();
        drum.GetComponent<Npc>().CloseAll();
        flower.GetComponent<Npc>().CloseAll();
        badWords.GetComponent<Npc>().CloseAll();
        lunPan.GetComponent<Npc>().CloseAll();
        tanxi.GetComponent<Npc>().CloseAll();
        Bag.instance.detect = false;
       
    }
}
