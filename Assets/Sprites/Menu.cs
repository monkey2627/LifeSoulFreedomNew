using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject start;
    public GameObject end;

    public AudioClip audioClip; // 要播放的音频剪辑
    public float fadeDuration = 15.0f; // 交叉淡化的持续时间
    public float delayBetweenLoops = 0.0f; // 循环之间的延迟时间（可选）

    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioSource currentSource;
    private AudioSource nextSource;
    private void OnEnable()
    {
        if(GameManager.instance)
            GameManager.instance.end = false;
        if (VoiceManager.instance)
        {
            VoiceManager.instance.gameObject.SetActive(true);
        }
        StartCoroutine(PlayAudioWithCrossFade());
    }
    private void OnDisable()
    {
        StopCoroutine(PlayAudioWithCrossFade());
    }
    private void Awake()
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

    public void EnterStart()
    {
        start.transform.DOScale(new Vector3(1.2f, 1.2f, 0), 0.2f);

    }
    public void ExitStart()
    {
        start.transform.DOScale(new Vector3(1f, 1f, 0), 0.2f);
    }
    public void EnterEnd()
    {
        end.transform.DOScale(new Vector3(1.2f, 1.2f, 0), 0.2f);
    }
    public void ExitEnd()
    {
        end.transform.DOScale(new Vector3(1f, 1f, 0), 0.2f);
    }
    public GameObject last;
    public void EnterLast()
    {
        last.transform.DOScale(new Vector3(1.2f, 1.2f, 0), 0.2f);
    }
    public void ExitLast()
    {
        last.transform.DOScale(new Vector3(1f, 1f, 0), 0.2f);
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
               // Debug.Log(fadeProgress+" "+fadeDuration +" "+t);
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
            yield return new WaitForSeconds(audioClip.length - fadeDuration + delayBetweenLoops-5);
        }
    }
}
