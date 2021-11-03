using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardScript : MonoBehaviour, IPointerDownHandler
{
    public GameObject prefabChar;
    public AudioSource[] sounds;
    private bool canSelect = true;


    public void OnPointerDown(PointerEventData eventData)
    {
        if (canSelect && !GameManager.removeEnabled && GameManager.currentCharacter == null
            && GameManager.cash >= prefabChar.GetComponent<CharacterProperties>().price)
            {
                GameManager.currentCard = gameObject;
                GameManager.currentCharacter = prefabChar;
                
                
                sounds[0].Play();
            }
        else if (!canSelect || GameManager.cash < prefabChar.GetComponent<CharacterProperties>().price)
        {
            sounds[1].Play();
        }
    }
    void Update()
    {
        if (!canSelect || GameManager.cash < prefabChar.GetComponent<CharacterProperties>().price)
        {
            GetComponent<Image>().color = new Color32(255, 255, 255, 60);
        }
        else
        {
            GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void StartRecharge()
    {
        canSelect = false;
        GameManager.currentCard = null;
        StartCoroutine ("WaitTime");
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(prefabChar.GetComponent<CharacterProperties>().timeRecharge);
        canSelect = true;
    }
}
