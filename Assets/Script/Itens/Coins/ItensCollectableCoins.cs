using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItensCollectableCoins : ItensCollectablesBase
{
    [Header("Collider ItemSetup")]
    public Collider _collider;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;

    private void Start()
    {
       // CoinsAnimationManager.Instance.RegisterCoin(this);
    }
    protected override void OnCollected()
    {
        base.OnCollected();
        _collider.enabled = false;
        collect = true;
        //PlayerControll.Instance.Bounce();
    }

    protected override void Collected()
    {
        OnCollected();
    }

    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position,
           PlayerControll.Instance.transform.position, lerp * Time.deltaTime);
            if (Vector3.Distance(transform.position, PlayerControll.Instance.transform.position) <
           minDistance)
            {
                HideItens();
                Destroy(gameObject);
            }
        }
    }



}
