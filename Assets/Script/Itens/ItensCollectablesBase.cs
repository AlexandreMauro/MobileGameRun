using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensCollectablesBase : MonoBehaviour
{
    public string PlayerTag = "Player";
    public ParticleSystem ParticleSystem;

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
        
        gameObject.SetActive(false);
        OnCollected();
    }

    protected virtual void OnCollected()
    {
        if (ParticleSystem != null) ParticleSystem.Play() ;
        if (audioSource != null) audioSource.Play();

    }


}
