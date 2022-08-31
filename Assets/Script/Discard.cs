using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Discard : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
       // Debug.LogWarning("drop");
    }
}
