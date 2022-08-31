using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManagerAnim : MonoBehaviour
{
    public GameObject CardMain;
    public int GameStartTime;
    public AudioManager ADM;
    public Sprite[] Diamond;
    public Sprite[] Club;
    public Sprite[] Spade;
    public Sprite[] heart;
    public Transform PosMine;
    public GameObject OpeningCardMine;
    public GameObject OpeningCardMineH;
    public Transform PosPlayer2;
    public GameObject OpeningCardPlayer2;
    public GameObject OpeningCardPlayer2H;
    public Color FadeColour;
    public Text warning;
    public GameObject CanvasBaseCard;
    public GameObject[] MyCard;
    public GameObject CanvCards;
    public GameObject[] MyCardAnim;
    public GameObject MyCardAnimBase;

    public void Start()
    {
        MainB.interactable = false;
        discard.SetActive(false);
    }
    public void CardAnim()
    {
        StartCoroutine(CardAnimaton());
    }
    public IEnumerator CardAnimaton()
    {
        yield return new WaitForSeconds(GameStartTime);
        ItweenSimpleVersion.Scale(CardMain, 1, 1, 1,2);
        ADM.playAudio(0);
        yield return new WaitForSeconds(2);
        SetRandomCard(OpeningCardMine);
        SetRandomCard(OpeningCardPlayer2);
        OpeningCardMine.SetActive(true);
        OpeningCardPlayer2.SetActive(true);
        ItweenSimpleVersion.MoveUI(OpeningCardMine, PosMine, 3);
        ItweenSimpleVersion.MoveUI(OpeningCardPlayer2, PosPlayer2, 3);
        yield return new WaitForSeconds(3);
        CheckWhoCanStart();
    }
    public IEnumerator StartCardDistrubution()
    {
        yield return new WaitForSeconds(2);
        Debug.LogWarning("Start Distribution");
        OpeningCardMine.SetActive(false);
        OpeningCardPlayer2.SetActive(false);
        OpeningCardPlayer2H.SetActive(false);
        OpeningCardMineH.SetActive(false);
        warning.text = "";
        yield return new WaitForSeconds(2);
        RandomMyCard();
        CanvasBaseCard.SetActive(true);
        MyCardAnimBase.SetActive(true);
        yield return new WaitForSeconds(1);
        StartCoroutine(CardAnimation());
    }
    public GameObject[] OpponentDummyCard;
    public GameObject[] OpponentCard;
    public GameObject OpponentCanvas;
    public IEnumerator CardAnimation()
    {
        int d = 0;
        foreach(GameObject C in MyCardAnim)
        {
            ItweenSimpleVersion.MoveUI(C,MyCard[d].transform,2);
            C.GetComponent<Image>().sprite = MyCard[d].GetComponent<Image>().sprite;
            d += 1;
            yield return new WaitForSeconds(1.3f);
        }
        yield return new WaitForSeconds(2.4f);
        OpponentCanvas.SetActive(true);
        StartCoroutine(CardAnimationOpponent());
        CanvCards.SetActive(true);
        yield return new WaitForSeconds(1);
        MyCardAnimBase.SetActive(false);
        StopCoroutine(CardAnimation());
    }
    public GameObject Opponentbase;
    public GameObject OpponentbaseDummy;
    public IEnumerator CardAnimationOpponent()
    {
        int d = 0;
        foreach (GameObject C in OpponentDummyCard)
        {
            ItweenSimpleVersion.MoveUI(C, OpponentCard[d].transform, 2);
            d += 1;
            yield return new WaitForSeconds(1.3f);
        }
        yield return new WaitForSeconds(2.4f);
        OpponentCanvas.SetActive(true);
        Opponentbase.SetActive(true);
        yield return new WaitForSeconds(1);
        OpponentbaseDummy.SetActive(false);
        StartCoroutine(StartGameMange());
        StopCoroutine(CardAnimationOpponent());
    }
   
    public void RandomMyCard()
    {
        foreach(GameObject c in MyCard)
        {
            SetRandomCard(c);
        }
    }
    public void CheckWhoCanStart()
    {
        if (CardNumber(OpeningCardMine) > CardNumber(OpeningCardPlayer2))
        {
            Debug.LogWarning("My Turn");
            warning.text = "You has won Cut for Seat , and you can start the hand";
            OpeningCardMineH.SetActive(true);
            OpeningCardPlayer2.GetComponent<Image>().color = FadeColour;
            StopCoroutine(CardAnimaton());
            StartCoroutine(StartCardDistrubution());
        }
        else
        {
            OpeningCardPlayer2H.SetActive(true);
            OpeningCardMine.GetComponent<Image>().color = FadeColour;
            Debug.LogWarning("Opponent Turn");
            warning.text = "Opponent has won Cut for Seat , and will start  the hand";
            StopCoroutine(CardAnimaton());
            StartCoroutine(StartCardDistrubution());
        }
    }
    public int CardNumber(GameObject c)
    {
        string[] d = c.GetComponent<Image>().sprite.name.Split(char.Parse("-"));
        return int.Parse(d[1]);
    }
    public string CardType(GameObject c)
    {
        string[] d = c.GetComponent<Image>().sprite.name.Split(char.Parse("-"));
        return d[0];
    }
    public void SetRandomCard(GameObject Card)
    {
        Card.GetComponent<Image>().sprite = RandomCard();
    }
    public Sprite RandomCard()
    {
        int CardsL = Random.Range(1, 5);
        if (CardsL == 1)
        {
            int d = Random.Range(0, 13);
            return Diamond[d];
        }
        else if(CardsL == 2){
            int c = Random.Range(0, 13);
            return Club[c];
        }
        else if (CardsL == 3)
        {
            int s = Random.Range(0, 13);
            return Spade[s];
        }
        else
        {
            int h = Random.Range(0, 13);
            return heart[h];
        }
    }

    public GameObject joker;
    public GameObject JokerCanv;
    public GameObject Main;
    public GameObject opendeck;
    public void JokerOn()
    {
        JokerCanv.SetActive(true);
        SetRandomCard(joker);
        ItweenSimpleVersion.Scale(joker, 1, 1, 1, 2);
    }
    public IEnumerator StartGameMange()
    {
        Main.SetActive(true);
        yield return new WaitForSeconds(1);
        JokerOn();
        opendeck.SetActive(true);
        MainB.interactable = true;
    }
    public GameObject P1;
    public GameObject P2;
    public GameObject PosFinal;
    public GameObject PosReturn;
    public int c = 0;
    public Button MainB;
    public GameObject discard;
    public void MainClick()
    {
        StartCoroutine(MainControl());
        MainB.interactable = false;
    }
    public void SetP(Sprite d)
    {
        if (P2.activeInHierarchy ==true)
        {
            P2.GetComponent<Image>().sprite = d;
        }
        else
        {
           
            P1.GetComponent<Image>().sprite = d;
        }
    }
    public IEnumerator MainControl()
    {
        if (c == 0)
        {
            c = 1;
            P1.SetActive(true);
            SetRandomCard(P1);
            ItweenSimpleVersion.MoveUI(P1, PosFinal.transform, 1);
            yield return new WaitForSeconds(1.3f);
            P2.transform.localPosition = PosReturn.transform.localPosition;
            P2.SetActive(false);
        }
        else
        {
            c = 0;
            P2.SetActive(true);
            SetRandomCard(P2);
            ItweenSimpleVersion.MoveUI(P2, PosFinal.transform, 1);
            yield return new WaitForSeconds(1.3f);
            P1.transform.localPosition = PosReturn.transform.localPosition;
            P1.SetActive(false);
        }
        
    }
    public Button next;
    public void NextButton(bool state)
    {
        next.enabled = state;
    }
    public void st()
    {
        discard.SetActive(true);
    }
    public void Next()
    {
        MainB.interactable = true;
    }
}
