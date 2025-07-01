using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouip : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.instance.TanChuangZhuangTai = true;
    }
    private void OnDisable()
    {
        GameManager.instance.TanChuangZhuangTai = false;
    }
}
