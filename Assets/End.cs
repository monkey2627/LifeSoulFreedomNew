using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
   public void SetEnd()
    {
        GameManager.instance.end = true;
    }
}
