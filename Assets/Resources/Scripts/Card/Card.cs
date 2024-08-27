using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Animator animator;
    private CardController cardController;
    private bool isClicked = false;
    private void Awake() {
        animator = GetComponent<Animator>();
        cardController = GameObject.FindWithTag("CardController").GetComponent<CardController>();
    }
    private void OnEnable() {
        isClicked = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetTrigger("MouseEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetTrigger("MouseLeave");
    }
    public void Hide(){
        animator.SetTrigger("Hide");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isClicked){
            cardController.Chose(gameObject);
            isClicked = true;
            GameObject.Find("Player").GetComponent<PlayerSound>().CardChoose();
        }
    }
}
