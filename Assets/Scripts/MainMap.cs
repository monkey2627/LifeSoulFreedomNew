using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMap : MonoBehaviour
{
    public static MainMap instance;
    private void Awake()
    {
        instance = this;
    }

}
