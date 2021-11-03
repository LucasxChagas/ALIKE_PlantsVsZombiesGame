using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CancelScript : MonoBehaviour, IPointerDownHandler
{
    public AudioSource sound;
    public void OnPointerDown(PointerEventData eventData)
    {
        if(GameManager.currentCharacter != null || GameManager.removeEnabled)
        {
            sound.Play();
            GameManager.currentCard = null;
            GameManager.currentCharacter = null;
            GameManager.removeEnabled = false;
            
        }
    }
}
