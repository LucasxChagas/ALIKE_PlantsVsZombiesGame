using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanScript : MonoBehaviour
{

    public GameObject prefabMoney;
    void Start()
    {
        InvokeRepeating("InstantiateMoney", 5, 20);
    }

    void InstantiateMoney()
    {
        var temp = Instantiate(prefabMoney, transform.position, Quaternion.identity) as GameObject;
        temp.GetComponent<MoneyScript>().newInstance = true;
    }

}
