using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public static Bridge instance;
    //
   


    // ��Inspector������������Ƶ����
    public AudioClip[] audioClips;

    // ��ƵԴ���
   public AudioSource audioSource;

    public AudioClip audioClip; // Ҫ���ŵ���Ƶ����
    public float fadeDuration = 5.0f; // ���浭���ĳ���ʱ��
    public float delayBetweenLoops = 0.0f; // ѭ��֮����ӳ�ʱ�䣨��ѡ��

    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioSource currentSource;
    private AudioSource nextSource;

    void Start()
    {
        instance = this;
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

        StartCoroutine(PlayAudioWithCrossFade());
        StartCoroutine(PlayRandomAudio());
    }

    IEnumerator PlayRandomAudio()
    {
        while (true)
        {
            // ���ѡ��һ����Ƶ����
            AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];

            // ������Ƶ
            audioSource.clip = randomClip;
            audioSource.Play();

            // �������1-3��ļ��ʱ��
            float delay = Random.Range(1.0f, 3.0f);

            // �ȴ���Ƶ������� + ������
            yield return new WaitForSeconds(randomClip.length + delay);
        }
    }



    public GameObject wu;
    public GameObject mirrors;
    public GameObject door;
    //̾Ϣ֮��
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
    //��Ц�ľ���
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
    //��
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
    /// �����֮�󴥷����
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
            // ������һ����ƵԴ
            nextSource.Play();

            // ��fadeDurationʱ������������һ����ƵԴ������
            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                float fadeProgress = t / fadeDuration;
                Debug.Log(fadeProgress + " " + fadeDuration + " " + t);
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
