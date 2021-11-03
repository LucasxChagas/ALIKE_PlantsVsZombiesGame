using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefabMoney;
    public Transform pointMoney;
    public static int cash;
    public static bool removeEnabled;
    public static GameObject currentCharacter, currentCard;


    void Start()
    {
        InvokeRepeating("InstantiateMoney", 10, 20);
        cash = 500;
        removeEnabled = false;
    }

    void Update()
    {
        if(cash >= 9999)
        {
            cash = 9999;
        }
    }

    void InstantiateMoney()
    {
        Instantiate(prefabMoney, pointMoney.position, Quaternion.identity);
    }
}
