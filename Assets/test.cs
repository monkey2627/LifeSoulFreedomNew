using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float rotateDuration = 0.02f; // 每次旋转的持续时间
    public int loopCount = 3; // 循环次数
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
        {

            transform.DORotate(new Vector3(0, 0, -10), 0.2f).OnComplete(() =>
            {

                transform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() =>
                {
                    transform.DORotate(new Vector3(0, 0, 0), 0.1f);

                });
            });

        });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
