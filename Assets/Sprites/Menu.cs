using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject start;
    public GameObject end;

    public AudioClip audioClip; // Ҫ���ŵ���Ƶ����
    public float fadeDuration = 15.0f; // ���浭���ĳ���ʱ��
    public float delayBetweenLoops = 0.0f; // ѭ��֮����ӳ�ʱ�䣨��ѡ��

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
            // ������һ����ƵԴ
            nextSource.Play();

            // ��fadeDurationʱ������������һ����ƵԴ������
            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                float fadeProgress = t / fadeDuration;
               // Debug.Log(fadeProgress+" "+fadeDuration +" "+t);
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
            yield return new WaitForSeconds(audioClip.length - fadeDuration + delayBetweenLoops-5);
        }
    }
}
