using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensCollectablesBase : MonoBehaviour
{
    public string PlayerTag = "Player";
    public ParticleSystem ParticleSystem;
    public float TimeToHide;
    public GameObject GraphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        if (ParticleSystem != null) ParticleSystem.transform.SetParent(null);
        if (audioSource != null) audioSource.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag(PlayerTag))
        {
            Collected();
        }
    }

   
    protected virtual void  Collected()
    {

        if (GraphicItem != null) GraphicItem.SetActive(false);
        Invoke(nameof(HideItens),TimeToHide);
        OnCollected();
    }

    public void HideItens()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollected()
    {
        if (ParticleSystem != null) ParticleSystem.Play() ;
        if (audioSource != null) audioSource.Play();

    }


}
