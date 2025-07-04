using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public GameObject[] guides;
    public AudioClip audioClip; // Ҫ���ŵ���Ƶ����
    public float fadeDuration = 0.3f; // ���浭���ĳ���ʱ��
    public float delayBetweenLoops = 0.0f; // ѭ��֮����ӳ�ʱ�䣨��ѡ��

    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioSource currentSource;
    private AudioSource nextSource;
    private void  Awake()
    {
        // ����������ƵԴ
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();

        audioSource1.clip = audioClip;
        audioSource2.clip = audioClip;

        audioSource1.loop = false;
        audioSource2.loop = false;

        audioSource1.playOnAwake = false;
        audioSource2.playOnAwake = false;

        // ��ʼ����ƵԴ
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
    /// �̳̽���
    /// ��ʼ��һ�����Ϸ������Init()
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
            // ������һ����ƵԴ
            nextSource.Play();

            // ��fadeDurationʱ������������һ����ƵԴ������
            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                float fadeProgress = t / fadeDuration;
               // Debug.Log(fadeProgress + " " + fadeDuration + " " + t);
                currentSource.volume = 1.0f - fadeProgress; // ��ǰ��ƵԴ�����𽥼�С
                nextSource.volume = fadeProgress; // ��һ����ƵԴ����������
                yield return null;
            }

            // ֹͣ��ǰ��ƵԴ
            currentSource.Stop();
            currentSource.volume = 1.0f; // ��������

            // ������ǰ����һ����ƵԴ
            AudioSource temp = currentSource;
            currentSource = nextSource;
            nextSource = temp;

            // �ȴ���Ƶ�������
            yield return new WaitForSeconds(audioClip.length - fadeDuration + delayBetweenLoops-6);
        }
    }
}

