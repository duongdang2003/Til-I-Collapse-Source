using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private GameObject[] cardList;
    public void Chose(GameObject cardChose){
        cardList = GameObject.FindGameObjectsWithTag("Card");
        foreach (GameObject card in cardList)
        {
            if (card != cardChose) card.GetComponent<Card>().Hide();
        }
    }
}
