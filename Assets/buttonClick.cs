using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonClick : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    Vector3 scale;
    private void Start()
    {
        scale = transform.localScale;
    }
  

    public void OnPointerEnter(PointerEventData eventData)
    {
       transform.DOScale(new Vector3(scale.x * 1.1f, scale.y * 1.1f, scale.z * 1.1f), 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    { 
            transform.DOScale(scale, 0.2f);
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.DOScale(scale, 0.2f);
    }
}
