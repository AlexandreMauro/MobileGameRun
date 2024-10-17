using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoins : PowerUpBase
{
    [Header("Coin Collector")]
    public float sizeAmount = 7;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerControll.Instance.SetPowerUpText("CoinCollect");
        PlayerControll.Instance.ChangeCoinCollectorSize(sizeAmount);
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerControll.Instance.SetPowerUpText("");
        PlayerControll.Instance.ChangeCoinCollectorSize(1);
    }

}
