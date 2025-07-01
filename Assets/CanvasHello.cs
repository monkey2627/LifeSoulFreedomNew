using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHello : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.instance.cards[(int)Card.Money].number += 1;
        Bag.instance.UpdateBag();
    }
}
