using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItensCollectableCoins : ItensCollectablesBase
{
   

    protected override void OnCollected()
    {
        base.OnCollected();
        ItenManager.Instance.addCoins();


    }

   
    

    
}
