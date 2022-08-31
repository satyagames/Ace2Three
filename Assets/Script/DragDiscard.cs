using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDiscard :MonoBehaviour, IPointerDownHandler ,IBeginDragHandler ,IEndDragHandler ,IDragHandler , IDropHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Ondrag");
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
      //  Debug.Log("droped");
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("drag end");
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked");
    }
}
