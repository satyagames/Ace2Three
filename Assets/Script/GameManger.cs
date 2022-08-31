using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public string UserNameTest;
    public int CoinTest;
    public string Player2Name;
    public CardManagerAnim CD;
    public AudioManager ADM;
    public void Start()
    {
        //for test
        GameData.UserName = UserNameTest;
        GameData.coin = CoinTest;
        GameData.Player2Name = Player2Name;
        Signal.SignalRange = 5;
    }
    public void StartGame()
    {
        CD.CardAnim();
    }

}
