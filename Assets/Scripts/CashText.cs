using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CashText : MonoBehaviour
{   
    [SerializeField] TMP_Text cashText;

    private void Update() {
    {
        cashText.text = GameManager.cash.ToString();
    }
    }
}