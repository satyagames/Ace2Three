using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTextbyData : MonoBehaviour
{
    public enum TypeText { UserName,Coin,Player2Name}
    public TypeText type;
    public void Update()
    {
        SetText();
    }
    public void SetText()
    {
        if (type == TypeText.UserName)
        {
            gameObject.GetComponent<Text>().text = GameData.UserName;
        }
        else if (type == TypeText.Coin)
        {
            gameObject.GetComponent<Text>().text = GameData.coin.ToString();
        }
        else if (type == TypeText.Player2Name)
        {
            gameObject.GetComponent<Text>().text = GameData.Player2Name;
        }
    }
}
