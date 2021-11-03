using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerDownHandler
{

    private bool isEmpty;

    [SerializeField] Color startColor, mouseOverAble, mouseOverUnable;
    bool mouseOver;

    void Update()
    {
        
        if (Physics.Raycast(transform.position, transform.up, 2f, LayerMask.GetMask("Character")))
        {
            isEmpty = false;
        }
        else
        {
            isEmpty = true;
        }
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (isEmpty && GameManager.currentCharacter != null)
        {
            Instantiate(GameManager.currentCharacter, new Vector3(transform.position.x, 0.02f, transform.position.z), Quaternion.Euler(0, -90, 0));
            GameManager.cash -= GameManager.currentCharacter.GetComponent<CharacterProperties>().price;
            GameManager.currentCharacter = null;
            GameManager.currentCard.GetComponent<CardScript>().StartRecharge();
        }
    }

    private void OnMouseEnter() 
    {
        mouseOver = true;    
        if (isEmpty == true)
        {
            GetComponent<Renderer>().material.SetColor("_Color", mouseOverAble);
        }
        else
        {
            GetComponent<Renderer>().material.SetColor("_Color", mouseOverUnable);
        }
    }

    private void OnMouseExit() 
    {
        mouseOver = false;    
        GetComponent<Renderer>().material.SetColor("_Color", startColor);
    }

}
