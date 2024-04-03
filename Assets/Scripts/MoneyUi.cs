using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyUi : MonoBehaviour
{

    public TextMeshProUGUI moneyText;

    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
