using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItensCollectablesBase
{
    [Header("PowerUp")]
    public float duration;
    protected override void OnCollected()
    {
        base.OnCollected();
        StartPowerUp();

    }

    protected virtual void StartPowerUp()
    {
        Invoke(nameof(EndPowerUp), duration);
    }
    protected virtual void EndPowerUp()
    {
        
    }
}
