using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Core.Singelton;
public class PlayerControll : Singelton<PlayerControll>
{
    //PUBLIC VARS
    [Header ("Lerp")]
    public Transform Target;
    public float LerpSpeed = 1f;
    public float velocity = 1f;


    [Header("Coin Setup")]
    public GameObject coinCollector;

    [Header("TextMeshPro")]
    public TextMeshPro uiTextPowerUp;

    [Header("Tags")]
    public string Enemy = "Enemy";
    public string EndLine = "EndLine";

    public GameObject EndScreen;
    public GameObject StartScreen;

    public bool invencible = false;
    
    //PRIVATE VARS
    private Vector3 _pos;
    private bool _CanRun;
    private float _currentSpeed;
    private Vector3 _startPosition;
    // Start is called before the first frame update


    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
        ResetHeight();
    }
    // Update is called once per frame
    void Update()
    {
        if (!_CanRun) return;

        
        _pos = Target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, LerpSpeed * Time.deltaTime);

        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == Enemy)
        {
           if(!invencible) EndGame();
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == EndLine )
        {
            if (!invencible) EndGame();
        }
       
           
        

    }
    private void EndGame()
    {
        EndScreen.SetActive(true);
        _CanRun = false;
    }
    public void StartGame()
    {
        _CanRun = true;
        StartScreen.SetActive(false);

    }

    #region PowerUps
    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }
    public void ResetSpeed()
    {
        _currentSpeed = velocity;
    }


    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }

    

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);//.OnComplete(ResetHeight);a
        Invoke(nameof(ResetHeight), duration);




    }
    public void ResetHeight()
    {
        /*var p = transform.position;
        p.y = _startPosition.y;
        transform.position = p;
        */
        transform.DOMoveY(_startPosition.y, .1f);
     
    }



    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
    #endregion
}
