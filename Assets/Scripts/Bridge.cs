using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{

    // 在Inspector中引用三个音频剪辑
    public AudioClip[] audioClips;

    // 音频源组件
   public AudioSource audioSource;

    void Start()
    {
      
        StartCoroutine(PlayRandomAudio());
    }

    IEnumerator PlayRandomAudio()
    {
        while (true)
        {
            // 随机选择一个音频剪辑
            AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];

            // 播放音频
            audioSource.clip = randomClip;
            audioSource.Play();

            // 随机生成1-3秒的间隔时间
            float delay = Random.Range(1.0f, 3.0f);

            // 等待音频播放完成 + 随机间隔
            yield return new WaitForSeconds(randomClip.length + delay);
        }
    }



    public GameObject wu;
    public GameObject mirrors;
    public GameObject door;
    //叹息之雾
    public GameObject wuOption;
    public GameObject wuDes;
    public GameObject wuOptDes1;
    


    private void OnEnable()
    {
        VoiceManager.instance.Bridge();
    }
    public void ClickWu()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (wu.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }   
      
        wu.GetComponent<Npc>().ClickTime += 1;
        wu.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            wu.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                wu.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    wu.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        wuOption.SetActive(true);
        wuDes.SetActive(true);
    }
    public void Wu()
    {
        wu.GetComponent<Animator>().SetBool("move", true);
        wuDes.SetActive(false);
        wuOption.SetActive(false);
        wu.GetComponent<SpriteRenderer>().DOFade(0, 1.5f).OnComplete(()=> {
            mirrors.SetActive(true);
            wu.SetActive(false);
            GameManager.instance.SubWorkPoint();
            Bag.instance.UpdateBag();
        });
    }
    //嬉笑的镜子
    public GameObject mOption;
    public GameObject mDes;
    public GameObject mOptDes1;
    public void ClickM()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (mirrors.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        mirrors.GetComponent<Npc>().ClickTime += 1;
       
        mirrors.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            mirrors.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                mirrors.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    mirrors.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        mOption.SetActive(true);
        mDes.SetActive(true);
    }
    public void Mirrors()
    {
        mirrors.GetComponent<SpriteRenderer>().DOFade(0, 1.5f).OnComplete(() => {
            door.SetActive(true);
            mirrors.SetActive(false);
            GameManager.instance.cards[(int)Card.Freedom].number += 1;
            GetPopup.instance.ShowGets(2);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
            Bag.instance.UpdateBag();
        });
    }
    //门
    public GameObject dOption;
    public GameObject dDes;
    public void ClickD()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        VoiceManager.instance.ClickTiezhi();
        if (door.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        door.GetComponent<Npc>().ClickTime += 1;
        if (door.GetComponent<Npc>().ClickTime >= 1)
        {
            return;
        }
        door.GetComponent<Npc>().ClickTime += 1;
        door.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            door.transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                door.transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                   door.transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
        dOption.SetActive(true);
        dDes.SetActive(true);
    }
    public GameObject jieshu;
    public void Door()
    {
        jieshu.SetActive(true);
    }
    public void Back()
    {
        if (GameManager.instance.TanChuangZhuangTai)
            return;
        MainMap.instance.gameObject.SetActive(true);
        VoiceManager.instance.CloseScence();
        gameObject.SetActive(false);
        Bag.instance.detect = false;
        VoiceManager.instance.CloseBridge();
        door.GetComponent<Npc>().CloseAll();
        mirrors.GetComponent<Npc>().CloseAll();
        wu.GetComponent<Npc>().CloseAll();
    }
    private void OnDisable()
    {
        Bag.instance.detect = false;
        VoiceManager.instance.CloseBridge();
        door.GetComponent<Npc>().CloseAll();
        mirrors.GetComponent<Npc>().CloseAll();
        wu.GetComponent<Npc>().CloseAll();
    }
}
