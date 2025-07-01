using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
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
}
