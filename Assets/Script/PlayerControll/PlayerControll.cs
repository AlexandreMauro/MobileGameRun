using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    //PUBLIC VARS
    [Header ("Lerp")]
    public Transform Target;
    public float LerpSpeed = 1f;
    public float velocity = 1f;



    [Header("Tags")]
    public string Enemy = "Enemy";
    public string EndLine = "EndLine";

    public GameObject EndScreen;
    public GameObject StartScreen;

    //PRIVATE VARS
    private Vector3 _pos;
    private bool _CanRun;
    // Start is called before the first frame update

    
    // Update is called once per frame
    void Update()
    {
        if (!_CanRun) return;

        
        _pos = Target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, LerpSpeed * Time.deltaTime);

        transform.Translate(transform.forward * velocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == Enemy)
        {
            EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == EndLine )
        {
            EndGame();
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
}
