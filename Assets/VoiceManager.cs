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
    /// µã»÷ÌùÖ½
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
        // ¼ì²âÊó±ê×ó¼üµã»÷
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
    public void Bridge()
    {
        Debug.Log("Brideg");
        main.clip = river;
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
    /// ¿¨ÅÆ²åÈë
    /// </summary>
    public AudioClip insertCard;
    public void InsertCard()
    {
        two.clip = insertCard;
        two.loop = false;
        two.Play();
    }
    public void CloseScence()
    {
        two.clip = closeScence;
        two.loop = false;
        two.Play();
        //±³¾°Òô±ä´ó
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
