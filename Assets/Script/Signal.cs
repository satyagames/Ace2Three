using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Signal : MonoBehaviour
{
    public Sprite[] SignalImage;
    public static int SignalRange;
    
    public void Update()
    {
        gameObject.GetComponent<Image>().sprite = SignalImage[SignalRange];
    }
}
