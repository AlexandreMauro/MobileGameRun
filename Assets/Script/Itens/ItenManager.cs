using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Singelton;

public class ItenManager : Singelton<ItenManager>
{
    [Header("Coins type 1")]
    public SOInt coins;
    public TextMeshProUGUI CoinText;
    [Header("Coins type 2")]
    public SOInt coins2;
    public TextMeshProUGUI CoinText2;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        

    }


    public void addCoins(int amaunt = 1)
    {
        coins.value += amaunt;
        CoinText.text = "X" + " " + coins.value.ToString();
    }

    public void addCoins2(int a = 2)
    {
        coins2.value += a;
        CoinText2.text = "X" + " " + coins2.value.ToString();
    }

}

