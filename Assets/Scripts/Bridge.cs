using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public static Bridge instance;
    //
   


    // 在Inspector中引用三个音频剪辑
    public AudioClip[] audioClips;

    // 音频源组件
   public AudioSource audioSource;

    public AudioClip audioClip; // 要播放的音频剪辑
    public float fadeDuration = 5.0f; // 交叉淡化的持续时间
    public float delayBetweenLoops = 0.0f; // 循环之间的延迟时间（可选）

    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioSource currentSource;
    private AudioSource nextSource;

    void Start()
    {
        instance = this;
        // 创建两个音频源
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();

        audioSource1.clip = audioClip;
        audioSource2.clip = audioClip;

        audioSource1.loop = false;
        audioSource2.loop = false;

        audioSource1.playOnAwake = false;
        audioSource2.playOnAwake = false;

        // 初始化音频源
        currentSource = audioSource1;
        nextSource = audioSource2;

        StartCoroutine(PlayAudioWithCrossFade());
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
    public GameObject wuOptDes;
    public void Wu()
    {
        wu.GetComponent<Animator>().SetBool("move", true);
        wuDes.SetActive(false);
        wuOption.SetActive(false);
        wuOptDes.SetActive(true);
        Bag.instance.UpdateBag();
        wu.GetComponent<SpriteRenderer>().DOFade(0, 1.5f).OnComplete(()=> {
            mirrors.SetActive(true);
            wu.SetActive(false);
            GameManager.instance.SubWorkPoint();
          
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
        wu.GetComponent<Npc>().CloseAll();
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
    { mOption.SetActive(false);mDes.SetActive(false);mOptDes1.SetActive(true); 
        GameManager.instance.cards[(int)Card.Freedom].number += 1;
        Bag.instance.UpdateBag();
        mirrors.GetComponent<SpriteRenderer>().DOFade(0, 1.5f).OnComplete(() => {

            door.SetActive(true);
            mirrors.SetActive(false);
            
            GetPopup.instance.ShowGets(2);
            GetPopup.instance.gameObject.SetActive(true);
            GetPopup.instance.work = true;
           
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
        mirrors.GetComponent<Npc>().CloseAll();
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
    /// <summary>
    /// 点击门之后触发结局
    /// </summary>
    public void Door()
    {
        VoiceManager.instance.StopMain();
        gameObject.SetActive(false);
        jieshu.SetActive(true);
        GameManager.instance.DisableAll();
    }
    private IEnumerator PlayAudioWithCrossFade()
    {
        while (true)
        {
            // 播放下一个音频源
            nextSource.Play();

            // 在fadeDuration时间内逐渐增大下一个音频源的音量
            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                float fadeProgress = t / fadeDuration;
                Debug.Log(fadeProgress + " " + fadeDuration + " " + t);
                currentSource.volume = 1.0f - fadeProgress; // 当前音频源音量逐渐减小
                nextSource.volume = fadeProgress; // 下一个音频源音量逐渐增大
                yield return null;
            }

            // 停止当前音频源
            currentSource.Stop();
            currentSource.volume = 1.0f; // 重置音量

            // 交换当前和下一个音频源
            AudioSource temp = currentSource;
            currentSource = nextSource;
            nextSource = temp;

            // 等待音频播放完成
            yield return new WaitForSeconds(audioClip.length - fadeDuration + delayBetweenLoops);
        }
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
        door.GetComponent<Npc>().CloseAll();
        mirrors.GetComponent<Npc>().CloseAll();
        wu.GetComponent<Npc>().CloseAll();
    }
}
