using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{
    [Header("Power Up Speed Up")]
    public float amountToSpeed;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerControll.Instance.PowerUpSpeedUp(amountToSpeed);
        PlayerControll.Instance.SetPowerUpText("Speed up");
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerControll.Instance.ResetSpeed();
        PlayerControll.Instance.SetPowerUpText("");
    }
}
