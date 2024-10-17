using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : PowerUpBase
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerControll.Instance.SetPowerUpText("Invencible");
        PlayerControll.Instance.SetInvencible();
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerControll.Instance.SetInvencible(false);
        PlayerControll.Instance.SetPowerUpText("");
    }

}
