using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    
    public static CardManager instance;


    [SerializeField] private GameObject cardHolder, cardPrefab, parentHolder, dummyCardPrefab;

    private CardView selectedCard, previousCard, nextCard; 
    int k, childCount;                                      
    private GameObject dummyCardObj;

    public CardView SelectedCard { get => selectedCard; }
    public GameObject ParentHolder { get => parentHolder; }
    public CardManagerAnim CDA;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {   
    }

    public void SelectCard(CardView card)
    {
        
        int selectedIndex = card.transform.GetSiblingIndex();
        selectedCard = card;                       
        selectedCard.ChildIndex = selectedIndex;    
        GetDummyCard().SetActive(true);             
        GetDummyCard().transform.SetSiblingIndex(selectedIndex);                                                
        selectedCard.transform.SetParent(CardManager.instance.ParentHolder.transform);

        childCount = cardHolder.transform.childCount;

        
        if (selectedIndex + 1 < childCount)
        {
            
            nextCard = cardHolder.transform.GetChild(selectedIndex + 1).GetComponent<CardView>();
        }

        if (selectedIndex - 1 >= 0)
        {
           
            previousCard = cardHolder.transform.GetChild(selectedIndex - 1).GetComponent<CardView>();
        }

        
    }
    public GameObject Discardc;
    public Transform discard;
    public void OnCardRelease()
    {

        if (Vector3.Distance(selectedCard.gameObject.transform.position, discard.position) < 40.0f) /* within 1 meter radius */
        {
            Debug.LogError("Dis");
            Discardc.SetActive(false);
            next.enabled = true;
            CDA.SetP(selectedCard.gameObject.GetComponent<Image>().sprite);
            Destroy(selectedCard.gameObject);
            
        }
        if (SelectedCard != null)
        {
            GetDummyCard().SetActive(false);       
            selectedCard.transform.SetParent(cardHolder.transform); 
                                                                    

            if (Mathf.Abs(selectedCard.transform.position.y - GetDummyCard().transform.position.y) > 80)
            {
                GetDummyCard().transform.SetParent(CardManager.instance.ParentHolder.transform);
                selectedCard.transform.SetSiblingIndex(selectedCard.ChildIndex);
            }
            else
            {
                selectedCard.transform.SetSiblingIndex(GetDummyCard().transform.GetSiblingIndex());
                GetDummyCard().transform.SetParent(CardManager.instance.ParentHolder.transform);
            }
            selectedCard = null;    
        }
    }

    
    public void MoveSelectedCard(Vector2 position)
    {
        if (selectedCard != null)                           
        {
            selectedCard.transform.position = position;     
            CheckWithNextCard();                            
            CheckWithPreviousCard();                       
        }
    }

    void CheckWithNextCard()
    {
        if (nextCard != null)
        {
            if (selectedCard.transform.position.x > nextCard.transform.position.x)
            {
                int index = nextCard.transform.GetSiblingIndex();
                nextCard.transform.SetSiblingIndex(dummyCardObj.transform.GetSiblingIndex());
                dummyCardObj.transform.SetSiblingIndex(index);

                previousCard = nextCard;
                if (index + 1 < childCount)
                {
                    nextCard = cardHolder.transform.GetChild(index + 1).GetComponent<CardView>();
                }
                else
                {
                    nextCard = null;
                }
            }
        }
    }

    void CheckWithPreviousCard()
    {
        if (previousCard != null)
        {
            if (selectedCard.transform.position.x < previousCard.transform.position.x)
            {
                int index = previousCard.transform.GetSiblingIndex();
                previousCard.transform.SetSiblingIndex(dummyCardObj.transform.GetSiblingIndex());
                dummyCardObj.transform.SetSiblingIndex(index);

                nextCard = previousCard;
                if (index - 1 >= 0)
                {
                    previousCard = cardHolder.transform.GetChild(index - 1).GetComponent<CardView>();
                }
                else
                {
                    previousCard = null;
                }
            }
        }
    }
    public Button next;
    #region Spawn Logic
    public void addCard(string name,Sprite sp)
    {
        GameObject cards = Instantiate(cardPrefab);
        cards.name = name;
        cards.GetComponent<Image>().sprite = sp;
        cards.transform.SetParent(cardHolder.transform);
        cards.GetComponent<RectTransform>().sizeDelta = new Vector2(130.0642f, 212.0059f);
        cards.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        
        // cards.AddComponent<CardView>();

    }
    GameObject GetDummyCard()
    {
        if (dummyCardObj == null)
        {
            dummyCardObj = Instantiate(dummyCardPrefab);
            dummyCardObj.name = "DummyCard";
            dummyCardObj.transform.SetParent(cardHolder.transform);
            dummyCardObj.GetComponent<RectTransform>().sizeDelta = new Vector2(130.0642f, 212.0059f);
            dummyCardObj.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            if (dummyCardObj.transform.parent != cardHolder.transform)
            {
                dummyCardObj.transform.SetParent(cardHolder.transform);
                dummyCardObj.GetComponent<RectTransform>().sizeDelta = new Vector2(130.0642f, 212.0059f);
                dummyCardObj.transform.localScale = new Vector3(1, 1, 1);
            }
            return dummyCardObj;
        }

        return dummyCardObj;
    }
    #endregion
}
