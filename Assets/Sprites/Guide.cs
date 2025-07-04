using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public GameObject[] guides;
    public AudioClip audioClip; // 要播放的音频剪辑
    public float fadeDuration = 0.3f; // 交叉淡化的持续时间
    public float delayBetweenLoops = 0.0f; // 循环之间的延迟时间（可选）

    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioSource currentSource;
    private AudioSource nextSource;
    private void  Awake()
    {
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

       
    }
    private void OnEnable()
    {
        GameManager.instance.DisableAll();
         StartCoroutine(PlayAudioWithCrossFade());
    }
    private void OnDisable()
    {
        StopCoroutine(PlayAudioWithCrossFade());
    }
    public void ClickGuide2()
    {
        Invoke("ShowGuide4", 3);
    }
    void ShowGuide4()
    {
        guides[3].SetActive(true);
    }
    public void ClickGuide4()
    {
        Invoke("ShowGuide6", 3);
    }
    void ShowGuide6()
    {
        guides[5].SetActive(true);
    }
    public void ClickGuide6()
    {
        guides[5].SetActive(false);
        guides[4].SetActive(false);
        guides[6].SetActive(true);
        Invoke("ShowGuide8", 3);
    }
    void ShowGuide8()
    {
        guides[7].SetActive(true);
    }
    public void ClickGuide8()
    {
        guides[7].SetActive(false);
        guides[6].SetActive(false);
        guides[8].SetActive(true);
        Invoke("ShowGuide10", 3);
    }
    void ShowGuide10()
    {
        guides[9].SetActive(true);
    }
    public void ClickGuide10()
    {
        guides[9].SetActive(false);
        guides[8].SetActive(false);
        guides[10].SetActive(true); 
       
        Invoke("ShowZhongbiao", 3);
    }
    public GameObject zhongbiao;
    public void ShowZhongbiao()
    {
 zhongbiao.SetActive(true);
        Invoke("ShowGuide12", 1);
    }
    void ShowGuide12()
    {
       
        guides[10].SetActive(false);
        guides[11].SetActive(true);
    }
    public GameObject Luodideng;

    /// <summary>
    /// 教程结束
    /// 开始第一天的游戏，运行Init()
    /// </summary>
    public void ClickGuide12()
    {

        guides[11].SetActive(false);
        VoiceManager.instance.gameObject.SetActive(true);
        VoiceManager.instance.PlayMain();
        Luodideng.SetActive(false);
        Bag.instance.gameObject.SetActive(true);
        zhongbiao.SetActive(false);
        GameManager.instance.UII.SetActive(true);
        DataManager.instance.NeedGuide = false;
        DataManager.instance.NeedHello = true;
        DataManager.instance.SaveGame();
        GameManager.instance.SolveDayHello();
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
               // Debug.Log(fadeProgress + " " + fadeDuration + " " + t);
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
            yield return new WaitForSeconds(audioClip.length - fadeDuration + delayBetweenLoops-6);
        }
    }
}

