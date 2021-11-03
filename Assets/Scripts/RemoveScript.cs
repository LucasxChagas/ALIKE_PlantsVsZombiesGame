using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RemoveScript : MonoBehaviour, IPointerDownHandler
{   
    public AudioSource sound;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(GameManager.currentCharacter == null && !GameManager.removeEnabled)
        {
            sound.Play();
            GameManager.removeEnabled = true;
            Instantiate(Resources.Load("remover", typeof(GameObject)) as GameObject, Input.mousePosition, Quaternion.identity);
        }
    }
}
