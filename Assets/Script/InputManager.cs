using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        if (CardManager.instance.SelectedCard != null)
        {
            CardManager.instance.MoveSelectedCard(eventData.position);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>() != null)
            {
                CardManager.instance.SelectCard(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>());
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
        }

        CardManager.instance.OnCardRelease();
    }
}
