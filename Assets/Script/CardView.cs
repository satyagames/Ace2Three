using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour 
{
    private Image img;
    private int childIndex;

    public int ChildIndex { get => childIndex; set => childIndex = value; }

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    public void SetCardImg(Sprite sprite)
    {
        img.sprite = sprite;
    }

    public void MoveCard()
    {
        Debug.Log("d");
    }
    
}
