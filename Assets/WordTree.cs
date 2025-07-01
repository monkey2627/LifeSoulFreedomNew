using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTree : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.instance.cards[(int)Card.Information].number += 1;
        Bag.instance.UpdateBag();
    }
}
