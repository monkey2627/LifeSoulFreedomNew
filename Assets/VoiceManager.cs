using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    public static VoiceManager instance;
    public AudioSource one;
    public AudioSource main;
    public AudioSource two;
    // Start is called before the first frame update
    public AudioClip mouseClick;
    public AudioClip closeScence;
    public AudioClip openBag;
    public AudioClip closeBag;
    public AudioClip river;
    public AudioClip mainBack;
    public AudioClip minBack;
    public AudioClip clickTiezhi;
    /// <summary>
    /// 点击贴纸
    /// </summary>
    public void ClickTiezhi()
    {
        two.clip = clickTiezhi;
        two.loop = false;
        two.Play();
    }
    void Start()
    {
        instance = this;   
    }

    // Update is called once per frame
    void Update()
    {
        // 检测鼠标左键点击
        if (Input.GetMouseButtonDown(0))
        {
            ClickMouse();
        }
    }
    public void IntoScene()
    {
        Debug.Log("into");
        main.clip = minBack;
        main.loop = true;
        main.Play();
    }
    public AudioClip BridgeBG;
    public void Bridge()
    {
        Debug.Log("Brideg");
        main.clip = BridgeBG;
        main.loop = true;
        main.Play();
    }
    public AudioClip move2NextDay;
    public void Move2NextDay()
    {
        two.clip = move2NextDay;
        two.loop = false;
        two.Play();
    }
    void ClickMouse()
    {
        one.clip = mouseClick;
        one.loop = false;
        one.Play();
    }
    public void CloseBridge()
    {
        main.clip = mainBack;
        main.loop = true;
        main.Play();
    }
    /// <summary>
    /// 卡牌插入
    /// </summary>
    public AudioClip insertCard;
    public void InsertCard()
    {
        two.clip = insertCard;
        two.loop = false;
        two.Play();
    }
    /// <summary>
    /// 标题界面中，鼠标经过选项时播放“鼠标经过选项”。点击选项时播放“confirm”
    /// </summary>
    public AudioClip mousePass;
    public void MousePass()
    {
        two.clip = mousePass;
        two.loop = false;
        two.Play();
    }
    public AudioClip mouseConfirm;
    public void MouseConfirm()
    {
        two.clip = mouseConfirm;
        two.loop = false;
        two.Play();
    }

    public void PlayMain()
    {
        main.clip = mainBack;
        main.loop = true;
        main.Play();
    }
    public void StopMain()
    {
        main.clip = null;
    }
    public void CloseScence()
    {
        two.clip = closeScence;
        two.loop = false;
        two.Play();
        //背景音变大
        main.clip = mainBack;
        main.loop = true;
        main.Play();
    }
   public void OpenBag()
    {
        two.clip = openBag;
        two.loop = false;
        two.Play();
    }
    public void CloseBag()
    {
        two.clip =closeBag;
        two.loop = false;
        two.Play();
    }


}
