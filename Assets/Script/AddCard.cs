using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCard : MonoBehaviour
{
    public CardManager CD;
    public void OnClick()
    {
        CD.addCard(gameObject.GetComponent<Image>().sprite.name, gameObject.GetComponent<Image>().sprite);
    }
}
